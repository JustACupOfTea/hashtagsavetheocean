using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isAttacking = animator.GetBool("isAttacking");
        bool isDead = animator.GetBool("isDead");

        if(!isAttacking &&  BossHitRange.instance.hittingPlayer)
        {
            animator.SetBool("isAttacking", true);
        }
        
        if(!isDead &&  BossStats.instance.bossHealth == 0)
        {
            animator.SetBool("isDead", true);
        } 

    
    }
}
