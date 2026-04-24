using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   bool isRoundActive;
   public bool isThereTarget;
   public NPCData target;
   public Sprite targetSprite;
   List<NPCData> npcs;
   public List<Sprite> levelFacePool;
   [SerializeField] GameObject npcPreFab;
    //The parent for the new gameobjects to spawn into
   [SerializeField] GameObject npcHolder;
   [SerializeField] int npcTotal = 10;
    List<GameObject> tvs;
    public  float MAXLEVELTIME = 120;
    public float currentLevelTime;

    private void Awake()
    {
         tvs = new List<GameObject>();
        npcs = new List<NPCData>();
        // Singleton setup. This allows us to keep the same audio manager, and only have 1 at a time.
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject); we will prob just want it to reload
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLevelTime = MAXLEVELTIME;
        StartNewRound();
    }
    private void Update()
    {
        currentLevelTime -= Time.deltaTime;
    }


    void StartNewRound()
    {
        isThereTarget = DecideIfTarget();
        GameObject[] foundTVs = GameObject.FindGameObjectsWithTag("TV");
        tvs.AddRange(foundTVs);
        //These maybe should not be here , but it helps with testing.
        StartWave();
        SetTvSprites();
    }
    
    //starts a new "wave" of NPCS. The first NPC spawned will be the target. Due to random spawn locations that doesnt matter.
    void StartWave()
    {
       
        for(int i = 0; i < npcTotal; i++)
        {
            if (i == 0 && isThereTarget)
            {
                setTargetSprite();
                npcs.Add(Instantiate(npcPreFab, new Vector3(0, 0, 0), Quaternion.identity, npcHolder.transform).GetComponent<NPCData>().SetTarget());

            }
            else
            {
                npcs.Add(Instantiate(npcPreFab, new Vector3(0, 0, 0), Quaternion.identity, npcHolder.transform).GetComponent<NPCData>());
            }       
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
        foreach (NPCData n in npcs)
        {
            Destroy(n.gameObject);
        }

        npcs.Clear();
    }

 
    void SetTvSprites()
    {
        foreach(GameObject tv in tvs)
        {
            tv.GetComponent<DisplayTVController>().SetTVTargetFace();
        }
    }

    bool DecideIfTarget()
    {
       if(Random.Range(0, 2) == 1)
        {
            return true;
        }
        else
        {
            setTargetSprite();
            return false;
        }
       
    }
}
