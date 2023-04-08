using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private Text healthText;
    public static int playerHealth = 100;


    private void Update()
    {
        healthText.text = "Health: " + playerHealth;
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            playerHealth = playerHealth - 10;
        }
    }
}
