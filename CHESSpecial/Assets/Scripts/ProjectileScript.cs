using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        if (transform.position.y <= 0) Destroy(gameObject);
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
