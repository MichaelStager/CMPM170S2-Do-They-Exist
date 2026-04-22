using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 0.6f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 0.07f;

    private Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            myLight.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}