using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This class handles the stats of the player, since it is within the XR object it isn't destroyed on load
 */
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
    
    public float timer{
        private set;
        get;
    }
    
    
    public bool bossFightTriggered
    {
        private set;
        get;
    }

    public bool finished;
    public bool started;
    public int maxHealth = 100;
    public float startTime;

    [SerializeField] private string level;
    //Boss ui
    [SerializeField] HealthBarPlayer hpBar;
   [SerializeField] HealthBarBoss hpBarBoss;
   [SerializeField] private Text bossName;

   private StartBossFight _startBossFight;
   
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            score = 200;
            playerHealth = 90;
            timer = 0;
            finished = false;
            started = false;
            bossFightTriggered = false;
            hpBar.SetMaxHealth();
            hpBar.SetHealth(playerHealth);
            hpBarBoss.gameObject.SetActive(false);
            bossName.gameObject.SetActive(false);
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(finished || !started)
            return;

        timer = Time.time - startTime;
    }

    public void ReduceHealth(int reduceBy)
    {
        playerHealth -= reduceBy;
        hpBar.SetHealth(playerHealth);
        AkSoundEngine.PostEvent("Play_Hurt", gameObject);
        
        // Check if player died
        if (playerHealth <= 0 && bossFightTriggered)
        {
            // Load defeat screen and play the corresponding music
            playerHealth = 0;
            finished = true;
            transform.GetComponentInChildren<Timer>().Finish();
            SceneManager.LoadSceneAsync(level);
            hpBarBoss.gameObject.SetActive(false);
            bossName.gameObject.SetActive(false);
            GameObject.Find("XR Origin").transform.position= Vector3.zero;
            AkSoundEngine.StopAll();
            AkSoundEngine.PostEvent("Play_Dungeon", gameObject);
            AkSoundEngine.SetState("music", "defeat");
            AkSoundEngine.PostEvent("Play_PlayerHelp", gameObject);
            
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
            _startBossFight = GameObject.Find("BossFightDetails").GetComponent<StartBossFight>();
            _startBossFight.InitiateBossFight(score, hpBarBoss, bossName, GameObject.Find("Timer Text").GetComponent<Timer>(),GameObject.Find("XR Origin").transform.position);
            playerHealth = maxHealth;
            bossFightTriggered = true;
        }
        
    }

     public void IncreaseScore(int increaseBy)
   {
      score += increaseBy;
   }

     public void ResetPlayerStats()
     {
         score = 0;
         playerHealth = 0;
         bossFightTriggered = false;
         finished = false;
         started = false;
         timer = 0;
         hpBar.SetHealth(playerHealth);
         GameObject.Find("Timer Text").GetComponent<Timer>().StartGame();
     }
}
