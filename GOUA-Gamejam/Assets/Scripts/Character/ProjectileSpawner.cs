using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
   
   [SerializeField] private GameObject projectile;    
   [SerializeField] private float projectileSpeed = 20f;     

    
    void Update()
    {
       Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;

           
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);

            
            Vector3 shootdirection = clickPosition - transform.position;
            float angle = Mathf.Atan2(shootdirection.y, shootdirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            bullet.GetComponent<Rigidbody2D>().velocity = shootdirection.normalized * projectileSpeed;
        }

    }
}


