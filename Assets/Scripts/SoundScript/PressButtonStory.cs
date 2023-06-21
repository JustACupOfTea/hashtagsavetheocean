using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a function to play the story
 */
public class PressButtonStory : MonoBehaviour
{
    public void PlayStory()
    {
        AkSoundEngine.PostEvent("Play_Story", gameObject);
    }
}
