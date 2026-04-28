using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float rayDistance = 3f;
    private Camera playerCamera;
    private NPCInterable currentHoveredNPC;

    private void Start()
    {
        playerCamera = Camera.main;
    }
private void Update()
    {
        if (playerCamera != null)
        {
            // Check for left mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // Create ray from camera through mouse position
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Cast the ray
                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    // Check if the hit object has NPCInterable component
                    NPCInterable npc = hit.collider.GetComponent<NPCInterable>();
                    if (npc != null)
                    {
                        // Interact with the NPC
                        npc.Interact();
                    }
                }
            }
        }
    }
}
    