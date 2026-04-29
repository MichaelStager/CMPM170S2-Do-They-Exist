using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   bool isRoundActive;
   public bool isThereTarget;
   [Tooltip("If toggled TRUE, there will always be a target spawned in the scene")]
   [SerializeField] bool isAlwaysTargetActive;
   public NPCData target;
   public Sprite targetSprite;
   List<NPCData> npcs;
   public List<Sprite> levelFacePool;
    public GameObject[] spawnPoints;
   [SerializeField] GameObject npcPreFab;
    //The parent for the new gameobjects to spawn into
   [SerializeField] GameObject npcHolder;
   [SerializeField] int npcTotal = 10;
    List<GameObject> tvs;
    public  float MAXLEVELTIME = 120;
    public float currentLevelTime;
    public AudioClip BackgroundAmbienceMusic;
    public AudioClip WaterDripAmbience;

    [SerializeField] AudioClip StageMusic;
    [SerializeField]bool changeBGM = false;
    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
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

        if(changeBGM)
        {
            AudioManager.Instance.PlayMusic(StageMusic);
            AudioManager.Instance.PlayMusic(BackgroundAmbienceMusic);
            AudioManager.Instance.PlayMusic(WaterDripAmbience);

        }
        currentLevelTime = MAXLEVELTIME;
        StartNewRound();
    }
    private void Update()
    {
        currentLevelTime -= Time.deltaTime;
        if(currentLevelTime < 0)
        {
            EndRound();
            //you lose type beat
        }
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
    //This is also handling deciding the random spawn location, pulling from the spawnpoint array.
    void StartWave()
    {
       
        for(int i = 0; i < npcTotal; i++)
        {
            if (i == 0 && isThereTarget)
            {
                setTargetSprite();
                npcs.Add(Instantiate(npcPreFab, spawnPoints[Random.Range(0,spawnPoints.Length)].gameObject.transform.position, Quaternion.identity, npcHolder.transform).GetComponent<NPCData>().SetTarget());

            }
            else
            {
                npcs.Add(Instantiate(npcPreFab, spawnPoints[Random.Range(0, spawnPoints.Length)].gameObject.transform.position, Quaternion.identity, npcHolder.transform).GetComponent<NPCData>());
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
        if(isAlwaysTargetActive)
        {
            return true;
        }
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

    public void StartWinSequence()
    {
        SceneSwapper.GoToNextLevel();
    }
    public void StartLoseSequence()
    {
        SceneSwapper.ReloadLevel();
    }
}
