using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            float interactionRange = 2f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange);
            foreach(Collider collider in colliders){
                if(collider.TryGetComponent(out NPCInterable npc)){
                    npc.Interact();
                }
            }
        }
    
    }
}
