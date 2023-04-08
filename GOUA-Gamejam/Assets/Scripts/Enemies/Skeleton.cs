using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float skeletonAttackRange = 1.0f;
    public int skeletonHealth = 100;

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
            // Add your attack code here
            Debug.Log("Skeleton attacking player!");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
            {
                skeletonHealth -= Knife.knifeDamage;
            }
        if (other.gameObject.tag == "Aura")
            {
                skeletonHealth -= Aura.auraDamage;
            }
        if (other.gameObject.tag == "Bible")
            {
                skeletonHealth -= Rotate.bibleDamage;
            }
        if (other.gameObject.tag == "Projectile")
            {
                skeletonHealth = skeletonHealth - Projectile.projectileDamage;
                Debug.Log("Çarptı");
            }
        if (skeletonHealth <= 0)
            {
                Die();
            }
        
    }

    

    private void Die()
    {
        // Add your death code here
        Debug.Log("Skeleton died!");
        Destroy(gameObject);
    }
}