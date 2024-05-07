using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    public GameObject prefab;
    public Transform bulletTransform;
    private float attackTimer;
    private float shootPeriod = 0f;
    public float shootingInterval = 0.5f; // Time between shots
   

    // Randomly decide the duration of the attack state
    private float GetRandomAttackDuration() => Random.Range(4f, 8f);

    // On entering the attack state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackTimer = GetRandomAttackDuration();
    }

    // During the attack state, handle shooting
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (shootPeriod > shootingInterval)
        {
            // Instantiate the bullet at the given transform
            if (bulletTransform != null)
                Instantiate(prefab, bulletTransform.position, Quaternion.identity);
            shootPeriod = 0;

        }
        shootPeriod += Time.deltaTime;

        // Count down the attack timer and transition back if time is up
        attackTimer -= Time.deltaTime;

        animator.SetTrigger("Attack");
    }

    // Reset everything when exiting the state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack"); // Ensure attack trigger is reset when exiting
        shootPeriod = 0; // Reset shooting timer
    }
}
