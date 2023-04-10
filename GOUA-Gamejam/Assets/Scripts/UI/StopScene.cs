using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScene : MonoBehaviour
{
    [SerializeField] private GameObject Stop;
    [SerializeField] private GameObject doubleBible;
    [SerializeField] private GameObject tripleBible;
    

    
    void Update()
    {
        if(Input.GetKey(KeyCode.E) == true){
            Time.timeScale = 0;
            Debug.Log("Deneme");
            Stop.SetActive(true);
            doubleBible.SetActive(false);
            tripleBible.SetActive(true);
        }
        if(Input.GetKey(KeyCode.Q) == true){
            Time.timeScale = 1;
            Debug.Log("Deneme");
            Stop.SetActive(false);
            doubleBible.SetActive(false);
            tripleBible.SetActive(true);
        }
        
    }
}
