using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    [field: SerializeField]
    public float playerHealth
    {
        private set;
        get;
    }

    public int score
    {
        private set;
        get;
    }
    [SerializeField] private string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float reduceBy)
    {
        playerHealth -= reduceBy;
        if (playerHealth <= 0)
        {
            SceneManager.LoadSceneAsync(level);
        }

    }

     public void IncreaseScore(int increaseBy)
   {
      score += increaseBy;
      Debug.Log("Score: " + score);
   }
}
