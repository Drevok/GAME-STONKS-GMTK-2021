using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScrip : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        characterController.SimpleMove(direction * speed);
    }
}
