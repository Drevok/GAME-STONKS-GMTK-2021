using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //RotateCharacter();
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        characterController.SimpleMove(direction * speed);
    }

    void RotateCharacter()
    {
        float mousePositionX = Input.GetAxisRaw("Mouse X");
        float mousePositionY = Input.GetAxisRaw("Mouse Y");
        
        //Vector3 direction = new Vector3(mousePositionX, 0, mousePositionY);

        transform.rotation = Quaternion.Euler(mousePositionX, mousePositionY, 0f);
    }

    public void Die()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
