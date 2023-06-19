using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (hittingPlayer && timePassedSinceLastHit>damageInterval)
        {
            animator.SetBool("IsAttacking", true);
            animator.SetBool("IsIdle", false);
            timePassedSinceLastHit = 0;
            hasHit = false;
        }
        else
        {
            if (animator.GetBool("IsAttacking") && timePassedSinceLastHit>2)
            {
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsIdle", true);
            }else if (animator.GetBool("IsIdle") && timePassedSinceLastHit>2.5 && !hasHit)
            {
                hasHit = true;
                PlayerStats.instance.ReduceHealth(damageToPlayer);
            }
        }
        timePassedSinceLastHit += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hittingPlayer = true;
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hittingPlayer = false;
        }
    }
}
