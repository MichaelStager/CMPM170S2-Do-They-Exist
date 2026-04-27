using UnityEngine;

public class NPCData : MonoBehaviour
{
    public bool isTarget = false;
    //The face sprite of the npc
    public SpriteRenderer npcFaceTarget;

    private void Awake()
    {
        if (!isTarget)
        {
            SetRandomFace();
        }
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

    
}
