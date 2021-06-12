using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public Camera _Camera;

    // Update is called once per frame
    private void Start()
    {
        _Camera = Camera.main;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(_Camera.transform.rotation.x, transform.rotation.y, transform.rotation.z);
        
    }
}
