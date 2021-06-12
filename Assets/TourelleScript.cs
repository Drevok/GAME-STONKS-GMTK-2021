using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TourelleScript : MonoBehaviour
{
    public Transform player;
    public float range;
    private float distanceFromPlayer;

    public GameObject pointLight;

    public GameObject cannon;

    public bool canShoot = true;

    public State _currentState;

    private void Start()
    {
        canShoot = true;
        pointLight.SetActive(false);
    }

    public enum State
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
                pointLight.SetActive(false);
                CheckDistanceFromPlayer();
                DecideToChange();
                break;
            case State.Detecting:
                pointLight.SetActive(true);
                DetectingPlayer();
                CheckDistanceFromPlayer();
                DecideToChange();
                break;
            case State.Shooting:
                pointLight.SetActive(true);
                DecideToChange();
                CheckDistanceFromPlayer();
                InitializeShoot();
                break;
            case State.Stunned:
                pointLight.SetActive(false);
                canShoot = false;
                StopCoroutine(ShootTimer());
                StartCoroutine(WaitForStun());
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
            StopAllCoroutines();
            canShoot = true;
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
        yield return new WaitForSeconds(2f);
        Shoot();
        yield return null;
    }

    void Shoot()
    {
        if (canShoot)
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, Vector3.forward);
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("J'ai touché le joueur");
                    player.GetComponent<CharacterScrip>().Die();
                }
            }
        }
    }

    IEnumerator WaitForStun()
    {
        yield return new WaitForSeconds(3f);
        _currentState = State.Shooting;
        yield return null;
    }
    
}
