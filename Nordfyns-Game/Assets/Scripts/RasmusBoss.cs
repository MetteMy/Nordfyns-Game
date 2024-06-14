using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasmusBoss : StateMachineBehaviour
{

    private shaking shakingScript;
  

    private EnemyHealth enemyHealth;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemyHealth = animator.GetComponent<EnemyHealth>();
        shakingScript = animator.GetComponent<shaking>();
        
        shakingScript.TriggerShake();
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        CheckHealthThreshold(animator);
    }


    private void CheckHealthThreshold(Animator animator)
    {
        switch (enemyHealth.health)
        {

            case 2:

                animator.SetTrigger("TransitionToState2");
                break;

            case 1:

                animator.SetTrigger("TransitionToState3");
                break;
            case 0:

                animator.SetTrigger("Dead");
                break;


        }

    }
}