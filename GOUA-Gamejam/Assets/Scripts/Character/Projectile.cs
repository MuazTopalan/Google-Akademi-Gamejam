using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public static int projectileDamage = 30;
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
    private void Update() 
    {
        Destroy(gameObject , 3f);
    }
}
