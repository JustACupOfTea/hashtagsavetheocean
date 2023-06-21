using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a function to play the sword sound
 */
public class GrabSword : MonoBehaviour
{
    public void PlaySwordSound()
    {
        AkSoundEngine.PostEvent("Play_Pick_Sword", gameObject);
    }
}
