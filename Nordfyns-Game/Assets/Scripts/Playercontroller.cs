using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput; 
    public float speed = 3.0f; 
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate() {

        body.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
    }
}
