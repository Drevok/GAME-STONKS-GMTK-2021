using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public Camera _camera;
    
    public GameObject laserPrefab;
    public GameObject shootPoint;
    public bool isShotFired;

    private Vector3 mousePos;

    private void Start()
    {
        
    }

    void Update()
    {
        RotateGun();
        ShootLaser();
    }
    
    void RotateGun()
    {
        mousePos = _camera.ScreenToViewportPoint(Input.mousePosition);
        
        
        transform.rotation = Quaternion.Euler(0f, mousePos.x *100, 0f);
    }

    void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isShotFired)
        {
            GameObject bullet = Instantiate(laserPrefab, shootPoint.transform.position, shootPoint.transform.localRotation);
            isShotFired = true;
        }
    }
}
