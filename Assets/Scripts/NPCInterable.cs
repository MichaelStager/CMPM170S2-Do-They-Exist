using UnityEngine;

public class NPCInterable : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject yesOrNoUiPanel;
    public static NPCInterable currentNPC;

    private bool ispopupopen = false;
    private bool wasOpenLastFrame = false;
    private bool wasCursorLocked = false;


    void Update()
    {
        if(ispopupopen && currentNPC == this && wasOpenLastFrame){
            if(Input.GetMouseButtonDown(0)){
                OnYesButtonClicked();
            }
            else if(Input.GetMouseButtonDown(1)){
                OnNoButtonClicked();
            }
        }
        wasOpenLastFrame = ispopupopen;
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
        ispopupopen = false;
    }
    //place holder for no
    public void OnNoButtonClicked()
    {
        Debug.Log("No button clicked for " + gameObject.name);
        yesOrNoUiPanel.SetActive(false);
        currentNPC = null;
        ispopupopen = false;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponent<InputController>().enabled = true;

    }
    
}
