using UnityEngine;

public class NPCData : MonoBehaviour
{
    bool isTarget = false;
    //The face sprite of the npc
    [SerializeField] SpriteRenderer npcFaceTarget;

    private void Awake()
    {
        SetRandomFace();
    }
    public void makeTarget()
    {
        isTarget = true;
        GameManager.Instance.target = this;
    }

    public bool getIsTarget()
    {
        return isTarget;
    }

    public void SetRandomFace()
    {
       npcFaceTarget.sprite = GameManager.Instance.levelFacePool[Random.Range(0, GameManager.Instance.levelFacePool.Length)];
    }

    
}
