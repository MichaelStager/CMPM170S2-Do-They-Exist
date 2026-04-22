using UnityEngine;
using UnityEngine.AI;

public class NPCWander : MonoBehaviour
{
    public float wanderRadius = 8f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 2f;

    private NavMeshAgent agent;
    private float waitTimer;
    private float currentWaitTime;
    private bool isWaiting;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewDestination();
    }

    void Update()
    {
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
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}