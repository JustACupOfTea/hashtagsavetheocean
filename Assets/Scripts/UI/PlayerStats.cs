using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    
    public static PlayerStats instance;
    
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

    public bool bossFightTriggered
    {
        private set;
        get;
    }
    
    [SerializeField] private string level;

   [SerializeField] HealthBar hpBar;
    public int maxHealth = 100;
    public GameObject boss;
    public Vector3 bossSpawnPoint;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            score = 0;
            playerHealth = 1;
            bossFightTriggered = false;
            hpBar.SetMaxHealth();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ReduceHealth(int reduceBy)
    {
        playerHealth -= reduceBy;
        hpBar.SetHealth(playerHealth);
        // Check if player died
        if (playerHealth <= 0 && bossFightTriggered)
        {
            playerHealth = 0;
            SceneManager.LoadSceneAsync(level);
        }

    }

      public void IncreaseHealth(int increaseBy)
    {
        // Check if the boss fight started
        if (!bossFightTriggered)
        {
            playerHealth += increaseBy;
            hpBar.SetHealth(playerHealth);
        }

        // Check if the boss fight should start
        if (playerHealth >= maxHealth && !bossFightTriggered)
        {
            //Spawn boss
            boss.GetComponent<AI_Boss>().prey = transform.parent.gameObject;
            Instantiate(boss, bossSpawnPoint, Quaternion.identity);
            
            playerHealth = maxHealth;
            bossFightTriggered = true;
        }
    }

     public void IncreaseScore(int increaseBy)
   {
      score += increaseBy;
   }
}
