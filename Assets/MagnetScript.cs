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
    
    public List<GameObject> objectsMagnetized = new List<GameObject>();
    public List<GameObject> lineList = new List<GameObject>();

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
         
         foreach (GameObject line in lineList)
         {
             line.GetComponent<LineScipt>().Die();
             //lineList.Remove(line);
         }
         
         objectsMagnetized.Clear();
        yield return null;
    }

    private void Update()
    {
        if (canMagnet)
        {
            //timeMagnet = timeMagnet + Time.deltaTime;
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, 6f);
            foreach (Collider c in colliders)
            {
                if (c.GetComponent<Rigidbody>())
                {
                    if (c.CompareTag("Magnetable"))
                    {
                        Vector3 distanceFromMagnetable = (c.transform.position - transform.position) * 100;
                        c.GetComponent<Rigidbody>().AddForce(-distanceFromMagnetable);
                        if (c.GetComponent<TourelleScript>())
                        {
                            c.GetComponent<TourelleScript>()._currentState = TourelleScript.State.Stunned;
                        }
                    }
                }
            }

            foreach (GameObject objectMagnetized in objectsMagnetized)
            {
                var line = Instantiate(LinePrefab);
                lineList.Add(line);
                line.GetComponent<LineScipt>().GetNewPositions(transform.position, objectMagnetized.transform.position);

            }
        }
        else
        {
            rb.isKinematic = false;
        }
    }
}
