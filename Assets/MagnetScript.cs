using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public GameObject LinePrefab;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {

    }

    public void ActivateMagnet()
    {
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
