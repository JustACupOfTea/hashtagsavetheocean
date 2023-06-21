using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * This script saves all the data for the boss fight and has a function to spawn the boss
 */
public class StartBossFight : MonoBehaviour
{
    public GameObject boss;
    public Vector3 bossSpawnPoint;
    public GameObject weapon;

    public void InitiateBossFight(int score, HealthBarBoss hpBarBoss, Text bossName, Timer timer, Vector3 playerPos)
    {
        //Spawn boss and set his stats
        boss.GetComponent<AI_Boss>().prey = GameObject.Find("XR Origin");
        boss.GetComponent<BossStats>().hpBarBoss = hpBarBoss;
        boss.GetComponent<BossStats>().bossName = bossName;
        boss.GetComponent<BossStats>().timer = timer;
        Instantiate(boss, bossSpawnPoint, Quaternion.identity);
        hpBarBoss.SetMaxHealth();
        hpBarBoss.gameObject.SetActive(true);
        bossName.gameObject.SetActive(true);

        //Spawn swords
        Vector3 weaponSpawn;
        if (score >= 200)
        {
            AkSoundEngine.PostEvent("Play_Heaven", gameObject);
            AkSoundEngine.PostEvent("Play_HolySwords", gameObject);
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
    }
}
