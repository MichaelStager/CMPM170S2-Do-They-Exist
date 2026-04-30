using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitDoor : MonoBehaviour
{
    public AudioClip doorOpenSFX;
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
            }
            else
            {
               GameManager.Instance.StartLoseSequence();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.PlaySFX(doorOpenSFX);
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
