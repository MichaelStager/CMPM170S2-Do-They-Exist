using UnityEngine;
using TMPro;
using System.Collections;

public class TextAnim : MonoBehaviour
{
    [Header("Settings")]
    public float typeSpeed = 0.05f;
    public float delayBeforeFade = 5f;
    public float fadeDuration = 1.5f;

    private TextMeshProUGUI tmpText;
    private string fullText;

    void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        fullText = tmpText.text;
        tmpText.text = "";
    }

    void Start()
    {
        StartCoroutine(PlayEffect());
    }

    IEnumerator PlayEffect()
    {
        foreach (char c in fullText)
        {
            tmpText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsedTime = 0;
        Color originalColor = tmpText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            tmpText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        
        gameObject.SetActive(false);
    }

}