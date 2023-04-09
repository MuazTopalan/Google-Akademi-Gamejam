using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    SpriteRenderer sr;
    private int movementSpeed = 5;
    
    Vector2 horizontalMovement;
    Vector2 verticalMovement;
    

    void Start()
    {
        horizontalMovement = new Vector2(movementSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime , 0);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(movementSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime , movementSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime ));
        if(Input.GetAxisRaw("Horizontal") < 0 )
        {
            sr.flipX = true;
        }
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Face();

        }
       
        
        
        
        
        
        
    }
    void Face(){
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if((mousePosition.x - transform.position.x) < 0)
        {
            sr.flipX = true;
        }
        if((mousePosition.x - transform.position.x) > 0)
        {
            sr.flipX = false;
        }
        
    }
    
}
