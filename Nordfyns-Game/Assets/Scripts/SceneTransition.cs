using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public string doorID;
    private bool canTransition;
    public AudioClip doorSound;
    public AudioClip lockSound; // Sound to play when transition is not allowed
    public int requiredBossesDefeated; // The number of bosses that need to be defeated to transition

    private void Start()
    {
        canTransition = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canTransition)
            {
                GameManager.Instance.lastDoorID = doorID;
                Debug.Log("Setting lastDoorID to: " + doorID);
                SceneManager.LoadScene(sceneToLoad);
                canTransition = false;
                PlayDoorSound();
            }
            else
            {
                PlayLockSound(); // Play the lock sound if transition is not allowed
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("scenetransition");

        if (other.CompareTag("Player"))
        {
            // Check if the required number of bosses have been defeated
            if (GameManager.Instance.bossesDefeated >= requiredBossesDefeated)
            {
                canTransition = true;
            }
            else
            {
                canTransition = false;
                Debug.Log("Not enough bosses defeated to transition.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTransition = false;
        }
    }

    void PlayDoorSound()
    {
        if (doorSound != null)
        {
            AudioManager.Instance.PlaySound(doorSound);
        }
    }

    void PlayLockSound()
    {
        if (lockSound != null)
        {
            AudioManager.Instance.PlaySound(lockSound);
        }
    }
}
