using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public GameObject LinePrefab;
    private float timeMagnet = 3f;
    private Rigidbody rb;

    private void Start()
    {
        timeMagnet = 10f;
        rb = GetComponent<Rigidbody>();
    }

    public void ActivateMagnet()
    {
        timeMagnet = 0;
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (timeMagnet <= 3f)
        {
            timeMagnet = timeMagnet + Time.deltaTime;
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
            foreach (Collider c in colliders)
            {
                if (c.GetComponent<Rigidbody>())
                {
                    Vector3 distanceFromMagnetable = (c.transform.position - transform.position) * 100;
                    c.GetComponent<Rigidbody>().AddForce(-distanceFromMagnetable);

                }
            }
        }
        else
        {
            rb.isKinematic = false;
        }
    }
}
