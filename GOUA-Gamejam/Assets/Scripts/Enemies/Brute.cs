using UnityEngine;

public class Brute : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float bruteAttackRange = 1.0f;
    public int bruteHealth = 200;
    [SerializeField] private GameObject bruteXP;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > bruteAttackRange)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

           
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
            Debug.Log("Çarptı");
        }
        if (bruteHealth <= 0)
        {
            Die();
        }

    }



    private void Die()
    {
        Instantiate(bruteXP , transform.position , Quaternion.identity);
        Debug.Log("Brute died!");
        Destroy(gameObject);
        
    }
}