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

    private Vector2 mousePos;

    private void Start()
    {
        //_camera = Camera.main;
    }

    void Update()
    {
        RotateGun();
        ShootLaser();
    }
    
    void RotateGun()
    {
        mousePos = _camera.ScreenToViewportPoint(Input.mousePosition);

        transform.rotation = Quaternion.Euler(mousePos.x, 0f, mousePos.y);
    }

    void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShotFired)
        {
            GameObject bullet = Instantiate(laserPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            isShotFired = true;
        }
    }
}
