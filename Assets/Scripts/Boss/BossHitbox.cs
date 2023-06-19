using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.gameObject.CompareTag("Sword") && timePassedSinceLastHit>damageInterval)
        {
            Debug.Log("DMG");
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
