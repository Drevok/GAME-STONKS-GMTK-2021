using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScipt : MonoBehaviour
{
    public LineRenderer _lineRenderer;


    private void Update()
    {
        //_lineRenderer.
    }

    public void GetNewPositions(Vector3 origin, Vector3 goal)
    {
        _lineRenderer.SetPosition(0, origin);
        _lineRenderer.SetPosition(1, goal);
    }

    public void Die()
    {
        Debug.Log("Je meurs aaaaaaaaaaaaaaaaaaaaaaa");
        Destroy(gameObject);
    }
}
