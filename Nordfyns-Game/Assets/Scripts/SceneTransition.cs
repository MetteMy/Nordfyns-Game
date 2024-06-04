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

    private void Start()
    {
        canTransition = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTransition == true)
        {
            GameManager.Instance.lastDoorID = doorID;
            Debug.Log("Setting lastDoorID to: " + doorID);
            SceneManager.LoadScene(sceneToLoad);
            canTransition = false;
            PlayDoorSound();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("scenetransition");

        if (other.CompareTag("Player"))
        {
            canTransition = true;
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
}
