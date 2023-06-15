using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IncreaseScore : MonoBehaviour
{

     [field: SerializeField]

    public int score
    {
        private set;
        get;
    }
   
     public Text scoreText;
     private int startScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "Score: " + startScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
     scoreText.text = "Score: " + startScore.ToString();
    }

   

}
