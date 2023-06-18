using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitRange : MonoBehaviour
{
     public static BossHitRange instance;
    [SerializeField] public float damageInterval;
    [SerializeField] public int damageToPlayer;
    public bool hittingPlayer;
    private float timePassedSinceLastSpawnTry = 0;
  
  void Awake()
    {
        if (instance == null)
        {
            instance = this;
         
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hittingPlayer = false;
        
    }

    // Update is called once per frame

    void Update()
    {
        if (hittingPlayer && timePassedSinceLastSpawnTry>damageInterval)
        {
            PlayerStats.instance.ReduceHealth(damageToPlayer);
            timePassedSinceLastSpawnTry = 0;
        }
        timePassedSinceLastSpawnTry += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hittingPlayer = true;
          
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hittingPlayer = false;
        }
    }
}
