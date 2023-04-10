using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 3f;
    public int arrowDamage = 10;

    private float timer;

    public void Fire(Vector2 direction)
    {
        transform.right = direction;
        GetComponent<Rigidbody2D>().velocity = direction * 10.0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterHealthAndXP.playerHealth -= arrowDamage;
            Destroy(gameObject);
        }
    }
}