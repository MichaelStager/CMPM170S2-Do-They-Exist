using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BackToStartDoor : MonoBehaviour
{
    public AudioClip doorOpenSFX;
    public AudioClip correctSFX;
    public AudioClip incorrectSFX;
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
        AudioManager.Instance.StopMusic();
        SceneManager.LoadScene(0);
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
