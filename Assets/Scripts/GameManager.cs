//TODO: SET THE TARGET TO A THE FIRST PERSON THAT SPAWNS, THEN REMOVE THAT FACE FROM THE LVL FACE POOL.
// 302----302----302-----302------302------302-----302------302-----302-----302-----302-----302----302 ( I seem to be trapped... inside... by chains...)

using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   bool isRoundActive;
   public NPCData target;
   public Sprite targetSprite;
   List<NPCData> npcs;
   public List<Sprite> levelFacePool;
   [SerializeField] GameObject npcPreFab;
    //The parent for the new gameobjects to spawn into
   [SerializeField] GameObject npcHolder;
   [SerializeField] int npcTotal = 10; 
    //float timer;
   // float maxTime = 120;
    private void Awake()
    {
        npcs = new List<NPCData>();
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
        //These maybe should not be here , but it helps with testing.
        setTargetSprite();
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //starts a new "wave" of NPCS. The first NPC spawned will be the target. Due to random spawn locations that doesnt matter.
    void StartWave()
    {
        for(int i = 0; i < npcTotal; i++)
        {
            if (i == 0)
            {
                npcs.Add(Instantiate(npcPreFab, new Vector3(0, 0, 0), Quaternion.identity,npcHolder.transform).GetComponent<NPCData>().SetTarget());
             
            }
            npcs.Add(Instantiate(npcPreFab, new Vector3(0, 0, 0), Quaternion.identity,npcHolder.transform).GetComponent<NPCData>());
        }
    }

    //sets the sprite for the targetNPC
    public void setTargetSprite()
    {
        
        targetSprite = levelFacePool[Random.Range(0, levelFacePool.Count)];
        levelFacePool.Remove(targetSprite);
    }

    //This is a clean up function for end of round.
    public void EndRound()
    {
        
    }
}
