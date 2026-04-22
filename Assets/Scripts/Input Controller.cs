using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public PlayerController playerController;
    private InputAction moveAction, lookAction;
    Vector2 moveVector;
    Vector2 lookVector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        playerController.Move(moveVector);

        lookVector = lookAction.ReadValue<Vector2>();
        playerController.Rotate(lookVector);

    }
}
