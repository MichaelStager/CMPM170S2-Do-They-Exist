using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HandleOutro : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject videoObject;
    [SerializeField] PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.StopMusic();
        videoPlayer.Play();
        playerController.enabled = false;
        // When the loop point (end of video) is reached fire the onvideoFinished void.
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        CleanUp();
    }

    private void CleanUp()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.enabled = true;
        videoObject.SetActive(false);
        videoPlayer.loopPointReached -= OnVideoFinished;
        Destroy(this);
    }
}
