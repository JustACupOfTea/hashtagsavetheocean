using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the hitbox of the boss, so that the player is able to hit him
 */
public class BossHitbox : MonoBehaviour
{
    [SerializeField] public int playerDamageToBoss;
    [SerializeField] public float damageInterval;
    public float timePassedSinceLastHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassedSinceLastHit += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has hit the boss with the swords and if enough time has passed since the last hit
        if (other.gameObject.CompareTag("Sword") && timePassedSinceLastHit>damageInterval)
        {
            // Check if it is the final blow
            if (BossStats.instance.bossHealth - playerDamageToBoss <= 0)
            {
                StartCoroutine(BossStats.instance.ReduceHealthDeath(playerDamageToBoss));
                timePassedSinceLastHit = 0;
            }
                
            else
            {
                BossStats.instance.ReduceHealth(playerDamageToBoss);
                timePassedSinceLastHit = 0;
            }
                
        }
    }
}
