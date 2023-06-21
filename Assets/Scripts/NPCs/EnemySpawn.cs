using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class spawns npcs randomly in a certain interval
 */
public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    // Spawn chance in percent-> Maybe relate to score
    public int spawnChance;
    // Spawn interval in seconds -> Maybe relate to score
    public float spawnInterval;

    private GameObject spawnedEnemy;
    private float timePassedSinceLastSpawnTry = 0;

    // Update is called once per frame
    void Update()
    {
        // Only try to spawn npc when -> No current npc ->Interval has passed -> Boss fight didn't start
        if (!spawnedEnemy && timePassedSinceLastSpawnTry>spawnInterval && !PlayerStats.instance.bossFightTriggered)
        {
            timePassedSinceLastSpawnTry = 0;
            int randomNumber1 = Random.Range(0, Mathf.RoundToInt(100/spawnChance));
            int randomNumber2 = Random.Range(0, 100/spawnChance); ;
            if (randomNumber1 == randomNumber2)
                SpawnEnemy(transform.position);

        }
        timePassedSinceLastSpawnTry += Time.deltaTime;
    }

    private void SpawnEnemy(Vector3 position)
    {
        spawnedEnemy = Instantiate(enemy, position, Quaternion.identity, transform);
    }
}
