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
        Vector3 bulletFront;
        bulletFront.x = GunScript.transform.forward.x;
        bulletFront.z = GunScript.transform.forward.z;
        bulletFront.y = 0f;
        rb.AddForce(bulletFront * 1000);
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
