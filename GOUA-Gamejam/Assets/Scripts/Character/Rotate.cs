using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 25;
    [SerializeField] GameObject player;
    void Update()
    {
        transform.RotateAround(player.transform.position , Vector3.forward ,  rotationSpeed *Time.deltaTime );
    }
}
