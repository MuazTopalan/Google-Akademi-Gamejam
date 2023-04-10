using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScene : MonoBehaviour
{
    [SerializeField] private GameObject Stop;
    

    
    void Update()
    {
        if(Input.GetKey(KeyCode.E) == true){
            Debug.Log("Deneme");
            Stop.SetActive(true);
        }
        
    }
}
