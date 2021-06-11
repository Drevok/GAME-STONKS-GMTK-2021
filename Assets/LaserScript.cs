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
}
