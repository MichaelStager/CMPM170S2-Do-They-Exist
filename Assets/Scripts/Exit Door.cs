using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitDoor : MonoBehaviour
{
    private GameObject ExitUi;
    private bool enableExit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ExitUi = GameObject.Find("ExitUI");
        ExitUi.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // Ensures player doesn't exist when not near door
        if(enableExit && Input.GetMouseButtonDown(1))
        {
            //If your is correct
            if(GameManager.Instance.target == null)
            {
                GameManager.Instance.StartWinSequence();
                
                // End level with win code here
            }
            else
            {
                Debug.Log("Wrong Guess");
                // end level code here  
            }
         
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enableExit = true;
            ExitUi.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enableExit = false;
            ExitUi.SetActive(false);
        }
    }
}
