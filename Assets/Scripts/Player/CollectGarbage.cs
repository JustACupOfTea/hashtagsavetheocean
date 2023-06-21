using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGarbage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Garbage")
        {
            uint[] playingIds = new uint[1];
            uint count = (uint)playingIds.Length;
            // Get all playing ids from currently playing sounds on this object
            AkSoundEngine.GetPlayingIDsFromGameObject(other.transform.GetChild(0).gameObject, ref count, playingIds);
            uint playingId = playingIds[0];
            Debug.Log(playingId);
            AkSoundEngine.StopPlayingID(playingId);
            Destroy(other.gameObject);
            PlayerStats.instance.IncreaseScore(50);
            AkSoundEngine.PostEvent("Play_Score", gameObject);
        }
    }
}
