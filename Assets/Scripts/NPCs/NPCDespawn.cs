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
            // Remove the current playing sound of the garbage
            uint[] playingIds = new uint[1];
            uint count = (uint)playingIds.Length;
            AkSoundEngine.GetPlayingIDsFromGameObject(other.transform.GetChild(1).gameObject, ref count, playingIds);
            uint playingId = playingIds[0];
            AkSoundEngine.StopPlayingID(playingId);
            Destroy(other.gameObject);
        }
    }
}
