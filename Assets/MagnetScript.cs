using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public GameObject LinePrefab;
    private float timeMagnet = 3f;

    private void Start()
    {
        timeMagnet = 10f;
    }

    public void ActivateMagnet()
    {
        timeMagnet = 0;
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
                    //Instantiate(LinePrefab) ;
                    //LinePrefab.GetComponent<LineScipt>().GetNewPositions(transform.position, c.transform.position);
                    Vector3 distanceFromMagnetable = (c.transform.position - transform.position) * 100;
                    c.GetComponent<Rigidbody>().AddForce(-distanceFromMagnetable);

                }
            }
        }
    }
}
