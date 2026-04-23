using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool isRoundActive;
    public NPCData target;
    public List<NPCData> npcs;//This might change from a gameObject to a NPC class object if we make one.
    public Sprite[] levelFacePool;
    [SerializeField] GameObject npcPreFab;
    //The parent for the new gameobjects to spawn into
    [SerializeField] GameObject npcHolder;
    int npcTotal = 10; 
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
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartWave()
    {
        for(int i = 0; i < npcTotal; i++)
        {
            npcs.Add(Instantiate(npcPreFab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<NPCData>());
        }
    }
}
