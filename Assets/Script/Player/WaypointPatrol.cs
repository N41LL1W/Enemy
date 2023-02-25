using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("Target")]
    public GameObject target;
    public string targetTag = "Player";
    public NavMeshAgent agentData;

    private void Awake()
    {
        agentData = GetComponentInParent<NavMeshAgent>();
    }

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
        //Animation
        animator.SetFloat("Move", navMeshAgent.velocity.magnitude);
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;
        string tag = target.tag;
        if (tag.Equals(targetTag) == false)
        {
            return;
        }

        Vector3 agentPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        Vector3 direction = targetPosition - targetPosition - agentPosition;
    }
}