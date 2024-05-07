using UnityEngine;

public class BossRunDory : StateMachineBehaviour
{
    
    
    private EnemyHealth enemyHealth;
    private BossTeleportScript teleportScript;

    // On entering the state, teleport and start shooting
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Teleport to a random point
       
        enemyHealth = animator.GetComponent<EnemyHealth>();
        teleportScript = animator.GetComponent<BossTeleportScript>();

        teleportScript.Teleport();

        

        
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
      
        CheckHealthThreshold(animator);
    }

 
    private void CheckHealthThreshold(Animator animator)
    {
        if (enemyHealth.health == 20)
        {
            animator.SetTrigger("TransitionToNextState"); // Set a trigger to transition to another state
        }

        if (enemyHealth.health == 10)
        {
            animator.SetTrigger("TransitionToNextState"); // Set a trigger to transition to another state
        }

        if (enemyHealth.health == 0)
        {
            animator.SetTrigger("TransitionToNextState"); // Set a trigger to transition to another state
        }
    }
}
