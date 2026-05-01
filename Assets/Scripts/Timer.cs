using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    
    private void Update()
    {
        float timeProgress = Mathf.Clamp01(
            GameManager.Instance.currentLevelTime / GameManager.Instance.MAXLEVELTIME
        );

        timerImage.fillAmount = timeProgress;
    }
}