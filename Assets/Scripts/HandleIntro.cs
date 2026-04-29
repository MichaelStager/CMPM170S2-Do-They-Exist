using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HandleIntro : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject videoObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer.Play();
        // When the loop point (end of video) is reached fire the onvideoFinished void.
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        CleanUp();
    }

    private void CleanUp()
    {
        videoObject.SetActive(false);
        videoPlayer.loopPointReached -= OnVideoFinished;
        Destroy(this);
    }
}
