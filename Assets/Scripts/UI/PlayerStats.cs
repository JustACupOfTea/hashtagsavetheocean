using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    [field: SerializeField]
    public int playerHealth
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

   [SerializeField] HealthBar hp;
    public int maxHealth = 100;
    public bool BossFightTriggered = false;

    
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = new PlayerStats();
            score = 0;
            playerHealth = 1;
            
            hp.SetMaxHealth();
         
        }
        

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ReduceHealth(int reduceBy)
    {
        playerHealth -= reduceBy;
        hp.SetHealth(playerHealth);
        if (playerHealth <= 0 && BossFightTriggered)
        {
            SceneManager.LoadSceneAsync(level);
        }

    }

      public void IncreaseHealth(int increaseBy)
    {
        playerHealth += increaseBy;
       
        hp.SetHealth(playerHealth);

        

    }

     public void IncreaseScore(int increaseBy)
   {
      score += increaseBy;
      Debug.Log("Score: " + score);
   }

    


}
