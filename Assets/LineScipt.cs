using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScipt : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    
    void Update()
    {
        
    }

    public void GetNewPositions(Vector3 origin, Vector3 goal)
    {
        _lineRenderer.SetPosition(0, origin);
        _lineRenderer.SetPosition(1, goal);
    }
}
