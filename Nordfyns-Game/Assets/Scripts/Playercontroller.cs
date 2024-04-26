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

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        // Always update animator with input values

        if (horizontalInput != 0 || verticalInput != 0)
        { 
        animator.SetFloat("xInput", horizontalInput);
        animator.SetFloat("yInput", verticalInput);
            animator.SetBool("isWalking", true);
        }else
        {
            animator.SetBool("isWalking", false);
        }


        // Debug output to check values
        Debug.Log("Horizontal Input: " + horizontalInput + ", Vertical Input: " + verticalInput);
    }
}
