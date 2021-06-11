using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody rb;
    public float laserSpeed = 1000f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, laserSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Player"))
        {
            if (other.collider.GetComponent<MagnetScript>())
            {
                other.collider.GetComponent<MagnetScript>().ActivateMagnet();
            }

            Destroy(gameObject);
        }
    }
}
