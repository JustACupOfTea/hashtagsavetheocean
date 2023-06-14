using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    // Spawn chance in percent-> Maybe relate to score
    public int spawnChance;
    // Spawn interval in seconds -> Maybe relate to score
    public float spawnInterval;

    private GameObject spawnedEnemy;
    private float timePassedSinceLastSpawnTry = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnedEnemy && timePassedSinceLastSpawnTry>spawnInterval)
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
