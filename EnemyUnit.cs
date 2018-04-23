using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyUnit : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private float freezeDuration;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        freezeDuration -= Time.deltaTime;
        navMeshAgent.isStopped = freezeDuration > 0;
    }

    internal void Freeze(float freezeDuration)
    {
        this.freezeDuration = freezeDuration;
        navMeshAgent.isStopped = true;
    }

    internal void SetDestination(Vector3 destinationTransform)
    {
        navMeshAgent.destination = destinationTransform;
        navMeshAgent.isStopped = false;
    }
}
