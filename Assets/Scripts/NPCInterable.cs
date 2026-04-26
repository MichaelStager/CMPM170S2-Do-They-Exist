using UnityEngine;

public class NPCInterable : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject yesOrNoUiPanel;
    public static NPCInterable currentNPC;

    private bool isPopUpOpen = false;
    private bool wasOpenLastFrame = false;
    private bool wasCursorLocked = false;

    private void Start()
    {
        yesOrNoUiPanel.SetActive(false);
    }
    void Update()
    {
        if(isPopUpOpen && currentNPC == this && wasOpenLastFrame){
            if(Input.GetMouseButtonDown(0)){
                OnYesButtonClicked();
            }
            else if(Input.GetMouseButtonDown(1)){
                OnNoButtonClicked();
            }
        }
        wasOpenLastFrame = isPopUpOpen;
    }
    public void Interact()
    {
        currentNPC = this;
        isPopUpOpen = true;
        yesOrNoUiPanel.SetActive(true);
        
        Debug.Log("Interacted with " + gameObject.name);

    }
    //place holder for yes
    public void OnYesButtonClicked()
    {
        Debug.Log("Yes button clicked for " + gameObject.name);
        yesOrNoUiPanel.SetActive(false);
        currentNPC = null;
        isPopUpOpen = false;
    }
    //place holder for no
    public void OnNoButtonClicked()
    {
        Debug.Log("No button clicked for " + gameObject.name);
        yesOrNoUiPanel.SetActive(false);
        currentNPC = null;
        isPopUpOpen = false;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponent<InputController>().enabled = true;

    }
    
}
