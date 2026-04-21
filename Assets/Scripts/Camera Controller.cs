using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 5f;
    float cameraVerticalRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -60f,60f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
    }
}
