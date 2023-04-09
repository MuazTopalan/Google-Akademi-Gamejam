using System.Collections;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public int rangerHealth = 100;

    public int rangerAttackDamage = 10;
    public float rangerAttackRange = 1.0f;
    private bool isAttacking = false;
    private float attackCooldown = 2.0f;
    private float timeSinceLastAttack = 0.0f;

    private Animator anim;

    private GameObject player;
    [SerializeField] private GameObject rangerXP;
    


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > rangerAttackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            if (isAttacking)
            {
                isAttacking = false;
                anim.SetBool("attacking", false);
            }

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (transform.position.x > player.transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else if (transform.position.x < player.transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            Debug.Log("ranger attacking player!");

            if (!isAttacking)
            {
                isAttacking = true;
                anim.SetBool("attacking", true);
            }

           

            if (timeSinceLastAttack >= attackCooldown)
            {
                timeSinceLastAttack = 0.0f;
                CharacterHealthAndXP.playerHealth -= rangerAttackDamage;
                StartCoroutine(DeactivateCollider());
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            rangerHealth -= Knife.knifeDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Aura")
        {
            rangerHealth -= Aura.auraDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Bible")
        {
            rangerHealth -= Rotate.bibleDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Projectile")
        {
            rangerHealth = rangerHealth - Projectile.projectileDamage;
            anim.SetTrigger("hurt");
        }
        if (rangerHealth <= 0)
        {
            Debug.Log("HP 0 or lower");
            anim.SetTrigger("die");
        }
    }

    private void Die()
    {
        Instantiate(rangerXP, transform.position, Quaternion.identity);
        Debug.Log("ranger died!");
        Destroy(gameObject);
    }

    IEnumerator DeactivateCollider()
    {
        yield return new WaitForSeconds(0.5f);
      
    }
}




