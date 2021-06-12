using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class TourelleScript : MonoBehaviour
{
    public Transform player;
    public float range;

    public GameObject cannon;

    private State _currentState;
    
    private enum State
    {
        Idle,
        Detecting,
        Shooting,
        Stunned
    };

    private void Update()
    {
        switch (_currentState)
        {
            case State.Idle:
                CheckDistanceFromPlayer();
                break;
            case State.Detecting:
                DetectingPlayer();
                break;
            case State.Shooting:
                Shoot();
                break;
            case State.Stunned:
                break;

        }
    }

    void CheckDistanceFromPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceFromPlayer <= range)
        {
            _currentState = State.Detecting;
        }
    }

    void DetectingPlayer()
    {
        float angle = Mathf.Atan2(player.transform.position.z, player.transform.position.x) * Mathf.Rad2Deg - 90f;
        cannon.transform.rotation = Quaternion.Lerp(cannon.transform.rotation, angle, 5f);
    }

    void Shoot()
    {
        
    }
}
