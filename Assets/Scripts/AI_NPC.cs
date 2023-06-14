using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_NPC : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public bool reachedTarget;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(transform.parent.GetChild(0).transform.position);
        reachedTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = navMeshAgent.nextPosition;
    }
}
