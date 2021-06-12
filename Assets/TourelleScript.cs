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

    public bool canShoot = true;

    private State _currentState;

    private void Start()
    {
        canShoot = true;
    }

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
                DecideToChange();
                CheckDistanceFromPlayer();
                InitializeShoot();
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

        if (distanceFromPlayer <= range && canShoot)
        {
            canShoot = false;
            _currentState = State.Shooting;
        }
    }

    void DetectingPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.localPosition - transform.position);
        //cannon.transform.rotation = Quaternion.Lerp(cannon.transform.localRotation, targetRotation, 5f);
        cannon.transform.rotation = targetRotation;
        
    }

    void InitializeShoot()
    {
        StartCoroutine(ShootTimer());
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(3f);
        Shoot();
        yield return null;
    }

    void Shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.forward);
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("J'ai touché le joueur");
            }
        }
    }
    
}
