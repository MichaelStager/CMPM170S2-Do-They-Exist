using UnityEngine;

public class NPCData : MonoBehaviour
{
    bool isTarget = false;
    public void makeTarget()
    {
        isTarget = true;
        GameManager.Instance.target = this.gameObject;
    }

    public bool getIsTarget()
    {
        return isTarget;
    }
}
