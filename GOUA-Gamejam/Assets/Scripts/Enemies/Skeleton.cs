using System.Collections;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public int skeletonHealth = 100;

    public int skeletonAttackDamage = 10;
    public float skeletonAttackRange = 1.0f;
    private bool isAttacking = false;
    private float attackCooldown = 2.0f;
    private float timeSinceLastAttack = 0.0f;

    private Animator anim;

    private GameObject player;
    [SerializeField] private GameObject skeletonXP;
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

        if (distanceToPlayer > skeletonAttackRange)
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
            Debug.Log("Skeleton attacking player!");

            if (!isAttacking)
            {
                isAttacking = true;
                anim.SetBool("attacking", true);
            }

            meleeCollider.gameObject.SetActive(true);

            if (timeSinceLastAttack >= attackCooldown)
            {
                timeSinceLastAttack = 0.0f;
                CharacterHealthAndXP.playerHealth -= skeletonAttackDamage;
                StartCoroutine(DeactivateCollider());
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            skeletonHealth -= Knife.knifeDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Aura")
        {
            skeletonHealth -= Aura.auraDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Bible")
        {
            skeletonHealth -= Rotate.bibleDamage;
            anim.SetTrigger("hurt");
        }
        if (other.gameObject.tag == "Projectile")
        {
            skeletonHealth = skeletonHealth - Projectile.projectileDamage;
            anim.SetTrigger("hurt");
        }
        if (skeletonHealth <= 0)
        {
            Debug.Log("HP 0 or lower");
            anim.SetTrigger("die");
        }
    }

    private void Die()
    {
        Instantiate(skeletonXP, transform.position, Quaternion.identity);
        Debug.Log("Skeleton died!");
        Destroy(gameObject);
    }

    IEnumerator DeactivateCollider()
    {
        yield return new WaitForSeconds(0.5f);
        meleeCollider.gameObject.SetActive(false);
    }
}