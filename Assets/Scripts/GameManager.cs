using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool isRoundActive;
    public GameObject target;  //This might change from a gameObject to a NPC class object if we make one.
    //float timer;
   // float maxTime = 120;
    private void Awake()
    {
        // Singleton setup. This allows us to keep the same audio manager, and only have 1 at a time.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
