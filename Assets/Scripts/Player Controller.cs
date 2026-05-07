using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{


     private CharacterController characterController;
     public float moveSpeed = 10f, RotationSpeed = 5f , sprintSpeed, baseMoveSpeed = 10f;
     private float roatationY;
     private float gravity = 9.81f;
     private float verticalVelocity;
     private Vector3 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        sprintSpeed = moveSpeed * 1.3f;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = baseMoveSpeed;
        }
    }
    public bool isMoving()
    {
        
        return move.x != 0 || move.z != 0;
    }

    public void Move(Vector2 movementVector)
    {
        move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * moveSpeed * Time.deltaTime;
        move.y = VerticalForceCalculation();
        characterController.Move(move);
        
    }
    public void Rotate(Vector2 rotateVector)
    {
        roatationY += rotateVector.x * RotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, roatationY, 0);
    }
    private float VerticalForceCalculation()
    {
        if(characterController.isGrounded)
        {
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

}
