using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public GameObject laserPrefab;
    public float launchSpeed = 100f;
    public GameObject shootPoint;

    // Update is called once per frame
    void Update()
    {
        //RotateGun();
        ShootLaser();
    }
    
    void RotateGun()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        transform.rotation = Quaternion.Euler(mousePos.x, 0f, mousePos.y);
    }

    void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(laserPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        }
    }
}
