using UnityEngine;
using UnityEngine.AI;

public class NPCWander : MonoBehaviour
{
    [Header("Wandering")]
    public float wanderRadius = 8f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 2f;

    [Header("Rotation")]
    public float turnSpeed = 5f;
    public float lookAtDistance = 10f;

    private NavMeshAgent agent;
    private GameObject player;

    private float waitTimer;
    private float currentWaitTime;
    private bool isWaiting;

    private bool isLocked = false;
    private bool isInteracting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        SetNewDestination();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        if (isLocked) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
                waitTimer = 0f;
            }
        }

        if (isWaiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= currentWaitTime)
            {
                isWaiting = false;
                SetNewDestination();
            }
        }
    }

    void SetNewDestination()
    {
        Vector3 randomPoint = GetRandomNavMeshPoint(transform.position, wanderRadius, 10);

        if (randomPoint != Vector3.zero)
        {
            agent.SetDestination(randomPoint);
        }
    }

    Vector3 GetRandomNavMeshPoint(Vector3 origin, float distance, int maxAttempts)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * distance;
            randomDirection += origin;

            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomDirection, out hit, 2.0f, NavMesh.AllAreas))
            {
                NavMeshPath path = new NavMeshPath();

                if (agent.CalculatePath(hit.position, path) && path.status == NavMeshPathStatus.PathComplete)
                {
                    return hit.position;
                }
            }
        }

        return Vector3.zero;
    }

 
    void HandleRotation()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (isInteracting)
        {
            RotateTowards(player.transform.position);
            return;
        }

        if (distanceToPlayer <= lookAtDistance)
        {
            RotateTowards(player.transform.position);
        }

        else
        {
            Vector3 velocity = agent.velocity;
            velocity.y = 0f;

            if (velocity.magnitude > 0.1f)
            {
                RotateTowards(transform.position + velocity);
            }
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }


    public void LockMovement()
    {
        isLocked = true;
        isInteracting = true;

        if (agent != null)
        {
            agent.isStopped = true;
            agent.ResetPath();
        }

        SnapToPlayer();
    }

    public void UnlockMovement()
    {
        isLocked = false;
        isInteracting = false;

        if (agent != null)
        {
            agent.isStopped = false;
        }

        SetNewDestination();
    }

    void SnapToPlayer()
    {
        if (player == null) return;

        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}