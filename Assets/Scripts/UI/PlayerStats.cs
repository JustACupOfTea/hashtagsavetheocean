using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //Boss fight
   
   [SerializeField] private string level;
   [SerializeField] HealthBarPlayer hpBar;
   [SerializeField] HealthBarBoss hpBarBoss;
   [SerializeField] private Text bossName;
   
   public GameObject boss;
    public Vector3 bossSpawnPoint;
    public GameObject weapon;
    
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
            Debug.Log("Awake Stats");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(started);
        if(finished || !started)
            return;

        timer = Time.time - startTime;
    }

    public void ReduceHealth(int reduceBy)
    {
        playerHealth -= reduceBy;
        hpBar.SetHealth(playerHealth);
        // Check if player died
        if (playerHealth <= 0 && bossFightTriggered)
        {
            playerHealth = 0;
            finished = true;
            transform.GetComponentInChildren<Timer>().Finish();
            SceneManager.LoadSceneAsync(level);
            hpBarBoss.gameObject.SetActive(false);
            bossName.gameObject.SetActive(false);
            GameObject.Find("XR Origin").transform.position= Vector3.zero;
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
            boss.GetComponent<AI_Boss>().prey = GameObject.Find("XR Origin");
            boss.GetComponent<BossStats>().hpBarBoss = hpBarBoss;
            boss.GetComponent<BossStats>().bossName = bossName;
            boss.GetComponent<BossStats>().timer = transform.GetComponentInChildren<Timer>();
            Instantiate(boss, bossSpawnPoint, Quaternion.identity);
            hpBarBoss.SetMaxHealth();
            hpBarBoss.gameObject.SetActive(true);
            bossName.gameObject.SetActive(true);

            //Spawn swords
            Vector3 weaponSpawn;
            Vector3 playerPos = transform.parent.transform.position;
            if (score >= 200)
            {
                weaponSpawn = new Vector3(playerPos.x+2, playerPos.y+10,playerPos.z);
                Instantiate(weapon, weaponSpawn, Quaternion.identity);
                if (score >= 400)
                {
                    weaponSpawn = new Vector3(playerPos.x-2, playerPos.y+10,playerPos.z);
                    Instantiate(weapon, weaponSpawn, Quaternion.identity);
                    if (score >= 600)
                    {
                        weaponSpawn = new Vector3(playerPos.x, playerPos.y+10,playerPos.z+2);
                        Instantiate(weapon, weaponSpawn, Quaternion.identity);
                        if (score >= 800)
                        {
                            weaponSpawn = new Vector3(playerPos.x, playerPos.y+10,playerPos.z-2);
                            Instantiate(weapon, weaponSpawn, Quaternion.identity);
                        }
                    }
                }
            }
            

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
