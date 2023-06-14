using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC" && other.gameObject.GetComponent<AI_NPC>().reachedTarget)
        {
            Destroy(other.gameObject);
        }
    }
}
