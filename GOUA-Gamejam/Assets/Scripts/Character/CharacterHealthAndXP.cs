using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthAndXP: MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text xpText;
    public static int playerHealth = 100;
    public static int xp = 0;

    private void Update()
    {
        healthText.text = "Health: " + playerHealth;
        xpText.text = "XP : " + xp;
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            playerHealth = playerHealth - 10;
        }
        if (other.gameObject.tag == "RangerArrow")
        {
            playerHealth = playerHealth - 5;
        }
        if (other.gameObject.tag == "SkeletonXP")
        {
            xp = xp + 100;
        }
        if(other.gameObject.tag == "RangerXP")
        {
            xp = xp + 200;           
        }
        if(other.gameObject.tag == "BruteXP")
        {
            xp = xp + 300;           
        }
    }
}
