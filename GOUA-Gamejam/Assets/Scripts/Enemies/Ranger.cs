using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public int rangerHealth = 100;

    public float rangerAttackCooldown = 1.0f;
    public float rangerAttackRange = 1.0f;
    private bool isAttacking;

    private Animator anim;

    private GameObject player;
    private Transform playerTransform;
    [SerializeField] private GameObject rangerXP;
    [SerializeField] private GameObject rangerArrowPrefab;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= rangerAttackRange && !isAttacking)
        {
            StartCoroutine(RangerAttack());
        }

        else if (distanceToPlayer > rangerAttackRange)
        {
            Debug.Log("Ranger moving towards the player!");

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

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
    }

    private IEnumerator RangerAttack()
    {
        Debug.Log("Ranger is attacking");
        isAttacking = true;
        anim.SetBool("attacking", true);

        GameObject arrow = Instantiate(rangerArrowPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        arrow.transform.right = direction;
        arrow.GetComponent<Rigidbody2D>().velocity = direction * 10.0f;

        yield return new WaitForSeconds(rangerAttackCooldown);

        isAttacking = false;
        anim.SetBool("attacking", false);
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
            Debug.Log("Ranger got hit");
            anim.SetTrigger("hurt");
        }
        if (rangerHealth <= 0)
        {
            Debug.Log("HP 0 or lower");
            anim.SetTrigger("die");
            Die();
        }
    }

    private void Die()
    {
        Instantiate(rangerXP, transform.position, Quaternion.identity);
        Debug.Log("Ranger died!");
        Destroy(gameObject);
    }
}