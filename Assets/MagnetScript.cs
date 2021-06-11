using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateMagnet();
        }
    }

    void ActivateMagnet()
    {
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
}
