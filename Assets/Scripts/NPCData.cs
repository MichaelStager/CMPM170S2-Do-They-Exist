using UnityEngine;
using UnityEngine.AI;

public class NPCData : MonoBehaviour
{
    public bool isTarget = false;
    //The face sprite of the npc
    public SpriteRenderer npcFaceTarget;
    [SerializeField] GameObject yesNoDisplay;
    InputController inputController;
    
    bool isBeingQuestioned;

    private void Awake()
    {
        inputController = FindAnyObjectByType<InputController>();
        isBeingQuestioned = false;
        yesNoDisplay.SetActive(false);
        if (!isTarget)
        {
            SetRandomFace();
        }
    }

    private void Update()
    {
        
    }

    //To set the NPC you want to be the target. Will talk with gamemanger to get the target sprite and markdown who is the target.
    public NPCData SetTarget()
    {
        isTarget = true;
        GameManager.Instance.target = this;
        npcFaceTarget.sprite = GameManager.Instance.targetSprite;
        return this;
    }

    public bool getIsTarget()
    {
        return isTarget;
    }

    public void SetRandomFace()
    {
       npcFaceTarget.sprite = GameManager.Instance.levelFacePool[Random.Range(0, GameManager.Instance.levelFacePool.Count)];
    }


    public void ClickedOn()
    {
        if (!isBeingQuestioned)
        {
            //This get a referance to the main camera of the scene to 
            Camera.main.GetComponent<CameraController>().LookAtTarget(this);
            isBeingQuestioned = true;
            //display the yesNoDispaly
            yesNoDisplay.SetActive(true);
            //Lock the enemy
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            inputController.enabled = false;
        }
        else
        {
            HandleQuestioning();
        }
    }

    void HandleQuestioning()
    {
        if (Input.GetMouseButtonDown(0) && isBeingQuestioned)
        {
            if(isTarget)
            {
                GameManager.Instance.StartWinSequence();
                yesNoDisplay.SetActive(false);
            }
            else
            {
             GameManager.Instance.StartLoseSequence();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            yesNoDisplay.SetActive(false);
            isBeingQuestioned = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            Camera.main.GetComponent<CameraController>().AllowControl();
            inputController.enabled = true;

        }
    }
}
