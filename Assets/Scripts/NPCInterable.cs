using UnityEngine;

public class NPCInterable : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject yesOrNoUiPanel;
    public static NPCInterable currentNPC;

    private bool ispopupopen = false;
    void Update()
    {
        if(ispopupopen && currentNPC == this){
            if(Input.GetMouseButtonDown(0)){
                OnYesButtonClicked();
            }
            else if(Input.GetMouseButtonDown(1)){
                OnNoButtonClicked();
            }
        }
    }
    public void Interact()
    {
        currentNPC = this;
        ispopupopen = true;
        yesOrNoUiPanel.SetActive(true);
        Debug.Log("Interacted with " + gameObject.name);
    }
    //place holder for yes
    public void OnYesButtonClicked()
    {
        Debug.Log("Yes button clicked for " + gameObject.name);
        yesOrNoUiPanel.SetActive(false);
        currentNPC = null;
    }
    //place holder for no
    public void OnNoButtonClicked()
    {
        Debug.Log("No button clicked for " + gameObject.name);
        yesOrNoUiPanel.SetActive(false);
        currentNPC = null;
    }
    
}
