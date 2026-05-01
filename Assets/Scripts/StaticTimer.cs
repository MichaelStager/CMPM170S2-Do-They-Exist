using UnityEngine;

public class StaticTimer : MonoBehaviour
{
    //For the world to change static over time
    public Material runtimeMaterial;
    private float maxStaticStrength = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(GameManager.Instance.currentLevelTime);
        float timeProgress = Mathf.Clamp01(GameManager.Instance.currentLevelTime / GameManager.Instance.MAXLEVELTIME) * 2;

        if (runtimeMaterial != null)
        {
            runtimeMaterial.SetFloat("_StaticStrength", maxStaticStrength - timeProgress );
        }

    }
}
