using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTurn : MonoBehaviour
{
    public GameObject[] garbage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC" && !other.GetComponent<AI_NPC>().reachedTarget)
        {
            AI_NPC ai = other.GetComponent<AI_NPC>();
            other.GetComponent<NavMeshAgent>().SetDestination(transform.parent.transform.position);
            ai.reachedTarget = true;
            GameObject selectedGarbage = garbage[Random.Range(0, garbage.Length)];
            selectedGarbage.GetComponent<Animation>().aStar = transform.parent.GetChild(1).gameObject;
            selectedGarbage.GetComponent<Animation>().gridPath = transform.parent.GetChild(1).GetComponent<Pathfinding>();
            
            Vector3 spawnPoint = transform.parent.GetChild(1).transform.position;
            Vector3 spawnPos = new Vector3(spawnPoint.x, GameObject.Find("Ocean").transform.position.y, spawnPoint.z);
            
            GameObject garb = Instantiate(selectedGarbage, spawnPos, Quaternion.identity);
            garb.transform.parent = transform.parent.GetChild(1).transform;
        }
    }
}
