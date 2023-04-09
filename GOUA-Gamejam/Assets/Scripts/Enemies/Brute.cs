using UnityEngine;
using System.Collections;

public class Brute : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public int bruteHealth = 200;

    public int bruteAttackDamage = 25;
    public float bruteAttackRange = 1.0f;
    private bool isAttacking = false;
    private float attackCooldown = 2.0f;
    private float timeSinceLastAttack = 0.0f;

    private Animator anim;

    private GameObject player;
    [SerializeField] private GameObject bruteXP;
    [SerializeField] private CircleCollider2D meleeCollider;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        meleeCollider.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > bruteAttackRange)
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
            Debug.Log("Brute attacking player!");

            if (!isAttacking)
            {
                isAttacking = true;
                anim.SetBool("attacking", true);
            }

            meleeCollider.gameObject.SetActive(true);

            if (timeSinceLastAttack >= attackCooldown)
            {
                timeSinceLastAttack = 0.0f;
                CharacterHealthAndXP.playerHealth -= bruteAttackDamage;
                StartCoroutine(DeactivateCollider());
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            bruteHealth -= Knife.knifeDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Aura")
        {
            bruteHealth -= Aura.auraDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Bible")
        {
            bruteHealth -= Rotate.bibleDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Projectile")
        {
            bruteHealth = bruteHealth - Projectile.projectileDamage;
            anim.SetTrigger("hurt");
        }
        if (bruteHealth <= 0)
        {
            Debug.Log("HP 0 or lower");
            anim.SetTrigger("die");     
        }
    }

    private void Die()
    {
        Instantiate(bruteXP, transform.position, Quaternion.identity);
        Debug.Log("Brute died!");
        Destroy(gameObject);
    }

    IEnumerator DeactivateCollider()
    {
        yield return new WaitForSeconds(0.5f);
        meleeCollider.gameObject.SetActive(false);
    }
}