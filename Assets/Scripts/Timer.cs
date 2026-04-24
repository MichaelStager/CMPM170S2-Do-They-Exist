using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI timerText;
  //  [SerializeField] string preTimerText = "TIME LEFT TILL MELTDOWN:";
    [SerializeField] Image timerImage;

    [SerializeField] UnityEngine.Color startColor;
    [SerializeField] UnityEngine.Color endColor;

    // Update is called once per frame
    void Update()
    {
        UpdateTimerFill();
    }

    void UpdateTimerFill()
    {
        // Starts at 1 then fractionally approaches 0
        float timeProgress = Mathf.Clamp01(GameManager.Instance.currentLevelTime / GameManager.Instance.MAXLEVELTIME);

        timerImage.fillAmount = timeProgress;

        // Extract and declare HSV interpolation colors
        UnityEngine.Color.RGBToHSV(startColor, out float startHue, out float startSaturation, out float startLight);
        UnityEngine.Color.RGBToHSV(endColor, out float endHue, out float endSaturation, out float endLight);
        // Lerps color from Green > Yellow > Red ( F00 > FF0 > 0F0 ) instead of Green > Brown > Red ( F00 > 770 > 0F0 )

        // Put End HSV values at 0 and Start HSV values at 1. The full timer begins with the starting color then reaches the ending color as it empties
        float hue = Mathf.LerpAngle(endHue, startHue, timeProgress);
        float saturation = Mathf.Lerp(endSaturation, startSaturation, timeProgress);
        float light = Mathf.Lerp(endLight, startLight, timeProgress);

        timerImage.color = UnityEngine.Color.HSVToRGB(hue, saturation, light);
    }
}
