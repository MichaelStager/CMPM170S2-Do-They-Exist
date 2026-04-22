using UnityEngine;


public class DisplayTVController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite[] faces;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            temp();
        }
    }
    // Temporary function to test setting a random tv face using SetTVFace()
    public void temp()
    {
        int randomIndex = Random.Range(0, faces.Length);
        SetTVFace(faces[randomIndex]);
    }
    
    public void SetTVFace(Sprite newFace)
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = newFace;
    }
}
