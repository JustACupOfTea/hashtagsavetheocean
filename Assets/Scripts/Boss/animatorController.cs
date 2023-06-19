using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animatorController : MonoBehaviour
{
    Animator animator;
    [SerializeField] public NavMeshAgent agent;
    
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
        bool isDead = animator.GetBool("IsDead");

        if(!isDead &&  BossStats.instance.bossHealth == 0)
        {
            animator.SetBool("IsDead", true);
        }

        if (agent.velocity == Vector3.zero)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }
}
