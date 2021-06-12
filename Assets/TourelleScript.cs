using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class TourelleScript : MonoBehaviour
{
    public Transform player;
    public float range;
    private float distanceFromPlayer;

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
                DecideToChange();
                break;
            case State.Detecting:
                DetectingPlayer();
                CheckDistanceFromPlayer();
                DecideToChange();
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
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    void DecideToChange()
    {
        if (distanceFromPlayer <= range)
        {
            _currentState = State.Detecting;
        }

        if (distanceFromPlayer > range)
        {
            _currentState = State.Idle;
        }
    }

    void DetectingPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.localPosition - transform.position);
        //cannon.transform.rotation = Quaternion.Lerp(cannon.transform.localRotation, targetRotation, 5f);
        cannon.transform.rotation = targetRotation;
    }

    void Shoot()
    {
        
    }
}
