using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject player;
    Vector3 direction;
    UnityEngine.AI.NavMeshAgent agent;
    
    public float turnSpeed = 5f;
    public float lookAtDistance = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        //case 1: player is within lookAtDistance, look at the player
        if (distanceToPlayer <= lookAtDistance) {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }
        }

        //case 2: player is outside lookAtDistance, look where moving
        else{
            Vector3 velocity = agent.velocity;
            velocity.y = 0f;

            // Only rotate if actually moving
            if (velocity.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(velocity);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }
        }
    }
}
