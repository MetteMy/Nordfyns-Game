using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip interactionSound; // Add this line

    bool canInteract = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract == true &&  Input.GetKeyDown(KeyCode.E)){
            Debug.Log("has been interacterd with "); 
            canInteract = false;
            PlayInteractionSound();

        }




    }

    void OnTriggerEnter2D(Collider2D other) { 

        if (other.CompareTag("interactable")){

            canInteract = true; 
           
            

        }
        
    }
    void PlayInteractionSound()
    {
        if (interactionSound != null)
        {
            AudioManager.Instance.PlaySound(interactionSound);
        }
    }


}
