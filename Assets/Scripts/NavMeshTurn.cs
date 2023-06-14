using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTurn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            AI_NPC ai = other.GetComponent<AI_NPC>();
            other.GetComponent<NavMeshAgent>().SetDestination(other.transform.parent.transform.position);
            ai.reachedTarget = true;

        }
    }
}
