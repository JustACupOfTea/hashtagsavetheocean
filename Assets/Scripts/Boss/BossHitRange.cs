using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the attack range of the boss
 */
public class BossHitRange : MonoBehaviour
{
    [SerializeField] public float damageInterval;
    [SerializeField] public int damageToPlayer;
    public bool hittingPlayer;
    public float timePassedSinceLastHit = 0;
    Animator animator;
    private bool hasHit; 
    // Start is called before the first frame update
    void Start()
    {
        hittingPlayer = false;
        animator = transform.parent.GetComponentInChildren<Animator>();
        hasHit = false;
    }

    // Update is called once per frame

    void Update()
    {
        // Check if the boss is able to attack
        if (hittingPlayer && timePassedSinceLastHit>damageInterval)
        {
            // Execute the hittin animation
            animator.SetBool("IsAttacking", true);
            animator.SetBool("IsIdle", false);
            timePassedSinceLastHit = 0;
            hasHit = false;
            
            AkSoundEngine.PostEvent("Play_Boss_Attack", gameObject);
        }
        else
        {
            // Check if the boss is currently within the attack animatio and if enough time has passed
            if (animator.GetBool("IsAttacking") && timePassedSinceLastHit>2)
            {
                // Go back to the idle animation
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsIdle", true);
            }else if (animator.GetBool("IsIdle") && timePassedSinceLastHit>2.5 && !hasHit)
            {
                // Reduce the player health
                hasHit = true;
                PlayerStats.instance.ReduceHealth(damageToPlayer);
            }
        }
        timePassedSinceLastHit += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player is within the hitrange, the boss is able to strike him/her
        if (other.gameObject.CompareTag("Player"))
        {
            hittingPlayer = true;
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player leaves the hitrange, the boss won't be able to hit him/her
        if (other.gameObject.CompareTag("Player"))
        {
            hittingPlayer = false;
        }
    }
}
