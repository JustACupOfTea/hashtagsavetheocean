using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Boss : MonoBehaviour
{
     public static AI_Boss instance;
    private NavMeshAgent navMeshAgent;

    public GameObject prey;
    // Start is called before the first frame update
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
         
        }
    }
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
        navMeshAgent.SetDestination(prey.transform.position);
        transform.position = navMeshAgent.nextPosition;
    }
}
