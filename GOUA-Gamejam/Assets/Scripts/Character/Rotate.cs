using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject player;

    public Transform target;
    public float orbitDistance = 10.0f;
    public float orbitDegreesPerSec = 180.0f;

    void Start()
    {
        rotationSpeed = 25f;
    }
    void Orbit()
    {
        transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
        transform.RotateAround(target.position, Vector3.forward, orbitDegreesPerSec * Time.deltaTime);


    }
    private void LateUpdate() {
        Orbit();
    }
}
