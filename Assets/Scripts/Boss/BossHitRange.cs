using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitRange : MonoBehaviour
{
    [SerializeField] public float damageInterval;
    [SerializeField] public int damageToPlayer;
    public bool hittingPlayer;
    public float timePassedSinceLastSpawnTry = 0;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        hittingPlayer = false;
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (hittingPlayer && timePassedSinceLastSpawnTry>damageInterval)
        {
            animator.SetBool("IsAttacking", true);
            timePassedSinceLastSpawnTry = 0;
        }
        else
        {
            
            if (animator.GetBool("IsAttacking") && timePassedSinceLastSpawnTry>2)
            {
                animator.SetBool("IsAttacking", false);
                PlayerStats.instance.ReduceHealth(damageToPlayer);
            }
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
