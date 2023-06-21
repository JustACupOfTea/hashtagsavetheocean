using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/*
 * This script uses the navmesh agent for the boss to chase down the player
 */
public class AI_Boss : MonoBehaviour
{
     
    private NavMeshAgent navMeshAgent;

    // The object to chase
    public GameObject prey;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(prey.transform.position);
        AkSoundEngine.PostEvent("Play_Final_Fight", gameObject);
        AkSoundEngine.SetState("music", "bossfight");
    }

    // Update is called once per frame
    void Update()
    {
        // Update the destination to prey position
        navMeshAgent.SetDestination(prey.transform.position);
        transform.position = navMeshAgent.nextPosition;
    }
}
