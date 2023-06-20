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
            Destroy(other.gameObject);
            PlayerStats.instance.IncreaseScore(50);
            AkSoundEngine.PostEvent("Play_Score", gameObject);
        }
    }
}
