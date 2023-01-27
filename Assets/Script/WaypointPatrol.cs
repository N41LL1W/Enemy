using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [Header("NavMeshAgent")]
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public int currentWaypoint;
    
    [Header("Animation")]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }
        animator.SetFloat("Move", navMeshAgent.velocity.magnitude);
    }
}
