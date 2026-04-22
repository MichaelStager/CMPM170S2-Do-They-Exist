using UnityEngine;
using UnityEngine.InputSystem.Android;

public class PlayerController : MonoBehaviour
{
     private CharacterController characterController;
     public float moveSpeed = 10f, RotationSpeed = 5f;
     private float roatationY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector)
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * moveSpeed * Time.deltaTime;
        characterController.Move(move);
    }
    public void Rotate(Vector2 rotateVector)
    {
        roatationY += rotateVector.x * RotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, roatationY, 0);
    }

}
