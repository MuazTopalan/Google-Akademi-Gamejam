using UnityEngine;

public class RangerShoot : MonoBehaviour
{
    public float rangerAttackCooldown = 1.0f;
    [SerializeField] private GameObject rangerArrowPrefab;

    private Transform playerTransform;
    private float timeSinceLastAttack;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (timeSinceLastAttack <= 0)
        {
            GameObject arrow = Instantiate(rangerArrowPrefab, transform.position, Quaternion.identity);
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            arrow.transform.right = direction; 
            arrow.GetComponent<Rigidbody2D>().velocity = direction * 10.0f;

            timeSinceLastAttack = rangerAttackCooldown;
        }
        else
        {
            timeSinceLastAttack -= Time.deltaTime;
        }
    }
}
