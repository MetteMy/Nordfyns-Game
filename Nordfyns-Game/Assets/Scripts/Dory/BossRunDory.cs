
using UnityEngine;

public class BossRunDory : StateMachineBehaviour
{


    private EnemyHealth enemyHealth;
    private BossTeleportScript teleportScript;
    private BossMultiplyScript multiplyScript;

    
    //private bool canTransition; 
    
    // Hash codes for each state


    // On entering the state, teleport and start shooting
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Teleport to a random point
        //canTransition = true; 

        enemyHealth = animator.GetComponent<EnemyHealth>();
        teleportScript = animator.GetComponent<BossTeleportScript>();
        multiplyScript = animator.GetComponent<BossMultiplyScript>();

        bool hasMultiplied = multiplyScript.hasMultiplied;
        
        //Debug.Log("enemyhealth on enter " + enemyHealth.health);
        //Debug.Log("hasMultiplied " + hasMultiplied);
        
        if (enemyHealth.health <= 10 && hasMultiplied == false){
            //Debug.Log("uiwhnifudfid");
            multiplyScript.Multiply();
        }
        else {
        
        teleportScript.Teleport();
        }
             
        
        // switch (enemyHealth.health)
        // {
        //     case 20:
        //         // Execute specific behavior for the "Run" state
        //         Debug.Log("20");
        //         teleportScript.Teleport();
                
        //         break;
        //     case 10:
        //         multiplyScript.Multiply();
        //         //; // Execute specific behavior for the "Stage 2" state
        //         break;
        //     case 5:
        //          // Execute specific behavior for the "Stage 3" state
        //         break;
        //     case 0:
        //         Debug.Log("enemy is dead"); // Execute specific behavior for the "Dead" state
        //         break;
        //     default:
        //         Debug.Log("Unknown state"); // Handle unknown states
        //         break;
            
        // }



    }






    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        CheckHealthThreshold(animator);
    }


    private void CheckHealthThreshold(Animator animator)
    {
        
            // case 23:

            //     animator.SetTrigger("TransitionToState1");
            //     break;
            //case 20:
        if (enemyHealth.health <= 20) {
            animator.SetTrigger("TransitionToState2");
        }

        //case 10:
        if (enemyHealth.health <= 10)
        {
            animator.SetTrigger("TransitionToState3");
            //break;
            //case 0:
        }
        if (enemyHealth.health <= 0)
        {
            animator.SetTrigger("Dead");
                //break;

        }

        // if (enemyHealth.health == 20 && canTransition == true)
        // {
        //     Debug.Log("transitioning state");
            

        //     animator.SetTrigger("TransitionToState2"); // Set a trigger to transition to another state
        //     canTransition = false;
        // }

        // if (enemyHealth.health == 15 && canTransition == true)
        // {
        //     Debug.Log("transitioning state");
        //     // multiplyScript.Multiply();
        //     animator.SetTrigger("TransitionToNextState"); // Set a trigger to transition to another state
        //     canTransition = false;
        // }

        // if (enemyHealth.health == 0 && canTransition == true)
        // {
        //     Debug.Log("enemy is dead");
        //     animator.SetTrigger("TransitionToNextState"); // Set a trigger to transition to another state
            
        // }
    }
}
