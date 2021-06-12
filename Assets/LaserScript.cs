using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody rb;
    public float laserSpeed = 1000f;
    public GunScript GunScript;

    private float timeShot;
    private void Start()
    {
        timeShot = 0;
        rb = GetComponent<Rigidbody>();
        GunScript = FindObjectOfType<GunScript>();
        rb.AddForce(0, 0, laserSpeed);
    }

    private void FixedUpdate()
    {
        timeShot += Time.deltaTime;

        if (timeShot >= 10)
        {
            GunScript.isShotFired = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Player"))
        {
            if (other.collider.GetComponent<MagnetScript>())
            {
                other.collider.GetComponent<MagnetScript>().ActivateMagnet();
            }

            else
            {
                GunScript.isShotFired = false;
            }

            Destroy(gameObject);
        }
    }
}
