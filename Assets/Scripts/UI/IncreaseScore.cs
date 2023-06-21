using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class updates the score in the ui within ui
 */
public class IncreaseScore : MonoBehaviour
{

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "Score: " + PlayerStats.instance.score;
    }

    // Update is called once per frame
    void Update()
    {
     scoreText.text = "Score: " + PlayerStats.instance.score;
    }

   

}
