using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel()
    {
        SceneManager.LoadSceneAsync(level);
        GameObject.Find("XR Origin").transform.position= Vector3.zero;
        if (level == "StartScreen")
        {
            AkSoundEngine.StopAll();
            AkSoundEngine.PostEvent("Play_Lobby_theme", gameObject);
            AkSoundEngine.SetState("music", "lobby");
            PlayerStats.instance.ResetPlayerStats();
        }else if (level == "SampleScene")
        {
            AkSoundEngine.StopAll();
            PlayerStats.instance.startTime = Time.time;
            PlayerStats.instance.started = true;
            
            AkSoundEngine.PostEvent("Play_Background_music", gameObject);
            AkSoundEngine.SetState("music", "scene");
        }
    }
}
