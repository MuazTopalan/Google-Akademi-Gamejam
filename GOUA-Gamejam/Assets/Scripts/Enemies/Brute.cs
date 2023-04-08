using UnityEngine;

public class Brute : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float skeletonAttackRange = 1.0f;
    public int bruteHealth = 200;

    private GameObject player;

    private void Start()
    {
        // Find the player object in the scene
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > skeletonAttackRange)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            // Flip sprite to face the player
            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else
        {
            // Stop moving and attack the player
            // Add attack code 
            Debug.Log("Skeleton attacking player!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            bruteHealth -= Knife.knifeDamage;
        }
        if (other.gameObject.tag == "Aura")
        {
            bruteHealth -= Aura.auraDamage;
        }
        if (other.gameObject.tag == "Bible")
        {
            bruteHealth -= Rotate.bibleDamage;
        }
        if (other.gameObject.tag == "Projectile")
        {
            bruteHealth = bruteHealth - Projectile.projectileDamage;
            Debug.Log("Çarptý");
        }
        if (bruteHealth <= 0)
        {
            Die();
        }

    }



    private void Die()
    {
        // Add death code here
        Debug.Log("Brute died!");
        Destroy(gameObject);
    }
}