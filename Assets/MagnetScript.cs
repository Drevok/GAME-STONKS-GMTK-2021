using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public GameObject LinePrefab;
    private bool canMagnet;
    private Rigidbody rb;

    private GunScript gunScript;

    private void Start()
    {
        canMagnet = false;
        rb = GetComponent<Rigidbody>();
        gunScript = FindObjectOfType<GunScript>();
    }

    public void ActivateMagnet()
    {
        canMagnet = true;
        StartCoroutine(WaitToShoot());
        rb.isKinematic = true;
    }

    IEnumerator WaitToShoot()
    {
         yield return new WaitForSeconds(3f);
         Debug.Log("ça fait trois secondes");
         canMagnet = false;
        gunScript.isShotFired = false;
        yield return null;
    }

    private void Update()
    {
        if (canMagnet)
        {
            //timeMagnet = timeMagnet + Time.deltaTime;
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
            foreach (Collider c in colliders)
            {
                if (c.GetComponent<Rigidbody>())
                {
                    if(c.CompareTag("Magnetable"))
                    {
                        Vector3 distanceFromMagnetable = (c.transform.position - transform.position) * 100;
                        c.GetComponent<Rigidbody>().AddForce(-distanceFromMagnetable);
                    }
                    
                }
            }
        }
        else
        {
            rb.isKinematic = false;
        }
    }
}
