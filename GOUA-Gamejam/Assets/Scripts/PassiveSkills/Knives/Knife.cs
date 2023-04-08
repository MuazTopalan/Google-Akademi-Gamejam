using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float knifeMovementSpeed = 1;
    [SerializeField] private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * knifeMovementSpeed);
        
        Destroy(gameObject , 3f);
       

        
    }
}
