using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Transform target;
    public float orbitDistance = 5.0f;
    public float orbitDegreesPerSec = 180.0f;
    public static int bibleDamage  = 30;
    void Orbit()
    {
        transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
        transform.RotateAround(target.position, Vector3.forward, orbitDegreesPerSec * Time.deltaTime);


    }
    private void LateUpdate() {
        Orbit();
    }
}
