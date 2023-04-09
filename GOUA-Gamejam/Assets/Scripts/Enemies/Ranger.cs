using UnityEngine;

public class Ranger : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rangerAttackRange = 1.0f;
    public int rangerHealth = 100;
    [SerializeField] private GameObject rangerArrowPrefab;


    private float timeSinceLastAttack;
    public float rangerAttackCooldown = 1.0f;
    private Transform playerTransform;

    private GameObject player;
    [SerializeField] private GameObject rangerXP;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }


    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= rangerAttackRange && timeSinceLastAttack <= 0)
        {
            // Stop 
            transform.position = transform.position;

            // Shoot 
            GameObject arrow = Instantiate(rangerArrowPrefab, transform.position, Quaternion.identity);
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            arrow.transform.right = direction;
            arrow.GetComponent<Rigidbody2D>().velocity = direction * 10.0f;

            timeSinceLastAttack = rangerAttackCooldown;
        }
        else if (distanceToPlayer > rangerAttackRange)
        {
            Debug.Log("Ranger moving towards the player!");
            // Move towards player
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
        timeSinceLastAttack -= Time.deltaTime;

        timeSinceLastAttack = Mathf.Max(timeSinceLastAttack, 0f);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            rangerHealth -= Knife.knifeDamage;
        }
        if (other.gameObject.tag == "Aura")
        {
            rangerHealth -= Aura.auraDamage;
        }
        if (other.gameObject.tag == "Bible")
        {
            rangerHealth -= Rotate.bibleDamage;
        }
        if (other.gameObject.tag == "Projectile")
        {
            rangerHealth = rangerHealth - Projectile.projectileDamage;
            Debug.Log("Ranger got hit");
        }
        if (rangerHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
     Instantiate(rangerXP, transform.position , Quaternion.identity);
     Debug.Log("Ranger died!");
     Destroy(gameObject);
    }
}