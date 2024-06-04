using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 3.0f;
    private Animator animator;
    Rigidbody2D body;
    private DialogueManager dialogueManager;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = GameManager.Instance.playerSpeed;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (dialogueManager != null && dialogueManager.IsDialogueActive())
        {
            horizontalInput = 0;
            verticalInput = 0;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

      

        if (horizontalInput != 0 || verticalInput != 0)
        { 
        animator.SetFloat("xInput", horizontalInput);
        animator.SetFloat("yInput", verticalInput);
            animator.SetBool("isWalking", true);
            TriggerFootstepSound();
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


     
        
    }

    public void TriggerFootstepSound()
    {
        AudioManager.Instance.PlayFootstepSound();
        
    }
}
