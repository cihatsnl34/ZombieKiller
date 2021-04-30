using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    CharacterController characterController;
    public int speed = 1;
    const float gravity = 9.8f;
   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

  
    void Update()
    {
        moveCharacter();
    }
   Vector3 moveVector;
    private void moveCharacter()
    {
        moveVector= new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,Input.GetAxis("Vertical")*speed*Time.deltaTime);
        moveVector = transform.TransformDirection(moveVector);
        if (!characterController.isGrounded)
        {
            moveVector.y -= Time.deltaTime * gravity;
        }
        characterController.Move(moveVector);
    }

 

}
