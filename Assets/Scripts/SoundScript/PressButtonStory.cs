using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonStory : MonoBehaviour
{
    public void PlayStory()
    {
        AkSoundEngine.PostEvent("Play_Story", gameObject);
    }
}
