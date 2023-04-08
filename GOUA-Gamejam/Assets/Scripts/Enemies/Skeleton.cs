using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float skeletonAttackRange = 1.0f;

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
}
