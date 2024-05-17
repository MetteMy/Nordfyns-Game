using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    private string[] currentSentences;
    private int index = 0;
    public bool isDialogueActive = false;
    private float dialogueCooldown = 0.1f; // Cooldown in seconds
    private float lastDialogueTime; // Time when the last dialogue action occurred
    public GameObject dialoguePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isDialogueActive && Time.time > lastDialogueTime + dialogueCooldown)
        {
            ContinueDialogue();
        }
    }

    public void StartDialogue(string[] sentences)
    {
        if (isDialogueActive || Time.time < lastDialogueTime + dialogueCooldown)
        {
            Debug.Log("Attempt to start dialogue, but dialogue is either active or on cooldown.");
            return;
        }

        currentSentences = sentences;
        index = 0;
        isDialogueActive = true;
        dialogueText.gameObject.SetActive(true);
        lastDialogueTime = Time.time;
        Debug.Log("Starting new dialogue.");
        ShowDialogue();
    }

    private void ContinueDialogue()
    {
        if (index < currentSentences.Length - 1)
        {
            index++;
            Debug.Log("Continuing dialogue, new index: " + index);
            ShowDialogue();
        }
        else
        {
            Debug.Log("Ending dialogue.");
            EndDialogue();
        }
    }

    private void ShowDialogue()
    {
        dialogueText.text = currentSentences[index];
        Debug.Log("Showing sentence: " + currentSentences[index]);
        lastDialogueTime = Time.time;
        dialoguePanel.gameObject.SetActive(true);
    }

    private void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        isDialogueActive = false;
        Debug.Log("Dialogue ended and deactivated.");
        lastDialogueTime = Time.time;
        dialoguePanel.gameObject.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
