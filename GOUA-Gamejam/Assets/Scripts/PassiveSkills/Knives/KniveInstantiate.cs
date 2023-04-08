using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KniveInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject doubleKnife;
    [SerializeField] private GameObject tripleKnife;
    [SerializeField] private GameObject quadraKnife;
    public static int multipleKnifeInstantiteFrequency = 3;
    public static int multipleKnifeChanger = 2;
    void Start()
    {
        InvokeRepeating("KnifeInstantiate" , 1 , multipleKnifeInstantiteFrequency);
    }

    void KnifeInstantiate()
    {
        if(multipleKnifeChanger == 2)
        {
            Instantiate(doubleKnife , transform.position , Quaternion.identity);

        }
        if(multipleKnifeChanger == 3)
        {
            Instantiate(tripleKnife , transform.position , Quaternion.identity);

        }
        if(multipleKnifeChanger == 4)
        {
            Instantiate(quadraKnife , transform.position , Quaternion.identity);

        }
        
        
    
    }
    
   
    
}
