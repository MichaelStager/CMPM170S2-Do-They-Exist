using UnityEngine;

public class RayInterator : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]float rayRange = 40;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            ShootRay();
        }
    }
        //Shoots a Raycast, then if it hits the enemy it will call the function on that enemy to display the UI. and we can then lock the charecter if needed as well.
        void ShootRay()
        {
            RaycastHit hit;
            // Shoot ray from the center of the camera forward
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
            {
                Debug.Log(hit.transform.gameObject.name);
               if(hit.transform.tag == "NPC")
                {
                    hit.transform.gameObject.GetComponent<NPCData>().ClickedOn();
                }

               
            }
        }
    
}
