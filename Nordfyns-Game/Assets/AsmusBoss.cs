using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsmusBoss : StateMachineBehaviour
{
   public int[] activeSpawnersIndexes;  // Array to specify which spawners should be active

    private SpawnerManager spawnerManager;

    private EnemyHealth enemyHealth;

    private AsmusMovement asmusMovement;

    private BossTeleportScript teleportScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemyHealth = animator.GetComponent<EnemyHealth>();
        teleportScript = animator.GetComponentInChildren<BossTeleportScript>();
        asmusMovement = animator.GetComponent<AsmusMovement>();
        asmusMovement.Move();
       //teleportScript.Teleport();

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
}