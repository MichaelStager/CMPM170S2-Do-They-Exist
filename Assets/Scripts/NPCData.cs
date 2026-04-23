using UnityEngine;

public class NPCData : MonoBehaviour
{
    bool isTarget = false;
    //The face sprite of the npc
    public SpriteRenderer npcFaceTarget;

    private void Awake()
    {
        SetRandomFace();
    }
    public NPCData SetTarget()
    {
        isTarget = true;
        GameManager.Instance.target = this;
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
