using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    public float groundSpeed;
    [Range(0f, 1f)]
    public float climbSpeed;
    [Range(0f, 1f)]
    public float groundDecay;
    public bool grounded;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal"); 
        if (Mathf.Abs(xInput) > 0)  //Updates the position of the player based on their inputs
        {
            body.linearVelocity = new Vector2(xInput * groundSpeed, body.linearVelocityY);
        }

    }

    void FixedUpdate()
    {
        CheckGrounded();    
        if (grounded && Input.GetAxis("Horizontal") == 0) //Applies friction to the player if they're on the ground
        {
            body.linearVelocity *= groundDecay;
        }
    }
    void CheckGrounded()    //Checks if the player is touching "ground" or not
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }
}
