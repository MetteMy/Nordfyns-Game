using UnityEngine;

public class LærkeBossFight : StateMachineBehaviour
{
    public int[] activeSpawnersIndexes;  // Array to specify which spawners should be active

    private SpawnerManager spawnerManager;

    private EnemyHealth enemyHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemyHealth = animator.GetComponent<EnemyHealth>();



        if (spawnerManager == null)
        {
            spawnerManager = animator.GetComponent<SpawnerManager>();
        }

        if (spawnerManager != null)
        {
            spawnerManager.SetActiveSpawners(activeSpawnersIndexes);
        }
        else
        {
            Debug.LogError("SpawnerManager not found on the Animator's GameObject.");
        }


       
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

            case 75:

                animator.SetTrigger("TransitionToState2");
                break;

            case 50:

                animator.SetTrigger("TransitionToState3");
                break;
            case 0:

                animator.SetTrigger("Dead");
                break;


        }

    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement any exit logic here if needed
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
