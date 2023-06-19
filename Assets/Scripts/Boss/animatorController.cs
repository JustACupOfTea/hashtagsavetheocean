using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour
{
    Animator animator;

    private BossHitRange bHR;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bHR = transform.parent.GetComponentInChildren<BossHitRange>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("IsWalking");
        bool isAttacking = animator.GetBool("IsAttacking");
        bool isDead = animator.GetBool("IsDead");
        bool isIdle = animator.GetBool("isIdle");
        
        
        // Insert idle if not walking and not attacking
        
        if(!isDead &&  BossStats.instance.bossHealth == 0)
        {
            animator.SetBool("IsDead", true);
        } 

    
    }
}
