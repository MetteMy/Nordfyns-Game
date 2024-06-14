using UnityEngine;
using TMPro;  // For TextMeshPro components
using UnityEngine.UI;  // For UI Panel

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool canTalk;
    public string[] sentences;
    private bool hasbeenTriggered;

    public bool TriggersBossBattle;

    private StartBossBattle startBossbattleScript;
    

    private void Start()
    {
        canTalk = false;
        startBossbattleScript = GetComponent<StartBossBattle>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTalk && !dialogueManager.IsDialogueActive())
        {
            TriggerDialogue();

            

        }
        if (TriggersBossBattle == true && hasbeenTriggered == true && dialogueManager.isDialogueActive == false){
                            
            Debug.Log("boss battle");
            startBossbattleScript.StartBattle();
            hasbeenTriggered = false; // because it had to be untrue, in order to stop it from happening again and you cant interact with the npc, so it doesnt matter
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTalk = false;
        }
    }

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(sentences);

        hasbeenTriggered = true; 
     
    }
}
