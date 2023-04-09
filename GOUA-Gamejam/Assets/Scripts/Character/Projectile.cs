using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public static int projectileDamage = 30;
    private bool animBool = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update() 
    {
        Destroy(gameObject , 3f);
        if(animBool == true)
        {
            StartCoroutine(Die());
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        animBool = true;

       
    }
    private IEnumerator Die()
    {
     
     yield return new WaitForSeconds(0.25f);
     Destroy(gameObject);
    }
}
