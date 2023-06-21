using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script handles the change between the different scenes
 */
public class LevelChange : MonoBehaviour
{
    [SerializeField] private string level;

    public void ChangeLevel()
    {
        // Load the new scene and reset the player position
        SceneManager.LoadSceneAsync(level);
        GameObject.Find("XR Origin").transform.position= Vector3.zero;
        if (level == "StartScreen")
        {
            // Stop the dialogue
            AkSoundEngine.StopAll();
            // Replay the lobby sound
            AkSoundEngine.PostEvent("Play_Lobby_theme", gameObject);
            AkSoundEngine.SetState("music", "lobby");
            // Reset the player stats
            PlayerStats.instance.ResetPlayerStats();
        }else if (level == "SampleScene")
        {
            // Stop the dialogue
            AkSoundEngine.StopAll();
            // Start the game
            PlayerStats.instance.startTime = Time.time;
            PlayerStats.instance.started = true;
            // Start the new backgrund music
            AkSoundEngine.PostEvent("Play_Background_music", gameObject);
            AkSoundEngine.SetState("music", "scene");
        }
    }
}
