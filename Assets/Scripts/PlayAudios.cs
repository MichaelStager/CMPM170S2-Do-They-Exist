using Unity.VisualScripting;
using UnityEngine;

public class PlayAudios : MonoBehaviour
{
    [SerializeField] AudioClip bgMusic;
    [SerializeField] AudioClip rockTalkSFX;
     void Start()
    {
     AudioManager.Instance.PlayMusic(bgMusic);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            rockTalk();
            AudioManager.Instance.StopMusic();
        }
    }
    public void rockTalk()
    {
        AudioManager.Instance.PlaySFX(rockTalkSFX);
    }
}
