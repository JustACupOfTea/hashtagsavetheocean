using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSword : MonoBehaviour
{
    public void PlaySwordSound()
    {
        AkSoundEngine.PostEvent("Play_Pick_Sword", gameObject);
    }
}
