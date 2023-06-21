using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script destroys garbage if it collides with this object
 */
public class CollectGarbage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Garbage")
        {
            // Remove the current playing sound of the garbage
            uint[] playingIds = new uint[1];
            uint count = (uint)playingIds.Length;
            AkSoundEngine.GetPlayingIDsFromGameObject(other.transform.GetChild(0).gameObject, ref count, playingIds);
            uint playingId = playingIds[0];
            AkSoundEngine.StopPlayingID(playingId);
            // Destroy the object, increase the score and play sound
            Destroy(other.gameObject);
            PlayerStats.instance.IncreaseScore(50);
            AkSoundEngine.PostEvent("Play_Score", gameObject);
        }
    }
}
