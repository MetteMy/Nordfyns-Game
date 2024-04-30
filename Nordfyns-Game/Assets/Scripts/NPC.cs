using UnityEngine;
using TMPro;  // For TextMeshPro components
using UnityEngine.UI;  // For UI Panel

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool canTalk;
    public string[] sentences;

    private void Start()
    {
        canTalk = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTalk && !dialogueManager.IsDialogueActive())
        {
            TriggerDialogue();
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
    }
}
