using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class despawns npcs when the reached their target and afterwards their spawn
 */
public class NPCDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") && other.gameObject.GetComponent<AI_NPC>().reachedTarget)
        {
            Destroy(other.gameObject);
        }
    }
}
