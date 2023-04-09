using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Attack();
        
    }

    void Walk()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("Walk" , true);

        
        }
        else
        {
            anim.SetBool("Walk" , false);
        }


    }
    void Attack()
    {
       if(Input.GetMouseButtonDown(0))
       {
        anim.SetBool("Fireball" ,true);
       }
       else
       {
        anim.SetBool("Fireball" , false);       
       }

    }
}
