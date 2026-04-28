using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 5f;
    float cameraVerticalRotation = 0f;
    float inputX;
    float inputY;
    bool canLookAround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Start()
    {
        canLookAround = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(canLookAround)
        {
         handlecontrols();
        }
    }

    public void LookAtTarget(NPCData target)
    {
        gameObject.transform.LookAt(target.npcFaceTarget.transform);
        canLookAround = false;
    }
    public void AllowControl()
    {
     canLookAround = true;
    }

    void handlecontrols()
    {

        inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -60f, 60f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
    }
}
