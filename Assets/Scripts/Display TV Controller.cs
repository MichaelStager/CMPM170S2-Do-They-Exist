using UnityEngine;


public class DisplayTVController : MonoBehaviour
{
    [SerializeField] SpriteRenderer tvScreen;

    
    public void SetTVTargetFace()
    {
        //prob need to change this to a serizalied feild because this will cause an error. if we have two sprite renders on an object.
        tvScreen.sprite = GameManager.Instance.targetSprite;
    }
}
