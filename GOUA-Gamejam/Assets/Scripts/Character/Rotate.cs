using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject player;

    void Start()
    {
        rotationSpeed = 25f;
    }
    void Update()
    {
        transform.RotateAround(player.transform.position , Vector3.forward ,  rotationSpeed * Time.deltaTime );
    }
}
