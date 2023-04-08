using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private int movementSpeed = 5;
    
    Vector2 horizontalMovement;
    Vector2 verticalMovement;
    

    void Start()
    {
        horizontalMovement = new Vector2(movementSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime , 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(movementSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime , movementSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime ));
        
    }
}
