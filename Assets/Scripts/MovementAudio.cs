using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class MovementAudio : MonoBehaviour
{
    [SerializeField] private AudioClip footsteps;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        StartCoroutine(PlayFootStep());
    }

    // Update is called once per frame
IEnumerator PlayFootStep()
    {
        while (true)
        {
            if(playerController.isMoving())
            {
                AudioManager.Instance.PlaySFX(footsteps);
                yield return new WaitForSeconds(.55f);
            }
            else
            {
                yield return null;
            }
            
         
           
        }

    }
}
