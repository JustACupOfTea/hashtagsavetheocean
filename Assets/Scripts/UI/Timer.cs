using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class updates the timer within the ui and adjusts its color depending on the state of the game
 */
public class Timer : MonoBehaviour
{
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        float t = PlayerStats.instance.timer;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        float t = PlayerStats.instance.timer;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        timerText.color = Color.red;
    }
    
    public void StartGame()
    {
        timerText.color = Color.white;
    }
}
