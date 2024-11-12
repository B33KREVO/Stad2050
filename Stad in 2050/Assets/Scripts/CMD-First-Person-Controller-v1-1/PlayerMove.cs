/* 
 * PLAYER MOVE
 * Moves the Player object according to key inputs.
 * Crouching and jumping are optional
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    public float walkingSpeed = 3.0f;
    public float jumpSpeed = 5.0f; // Updated for better jumping
    public bool jumpEnabled;
    public bool crouchEnabled;
    public float crouchHeight = 0.4f;
    private float normalHeight;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.LeftControl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalHeight = transform.localScale.y;
        rb.freezeRotation = true; // Prevents unintended rotations
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        bool hasInput = false;

        // Walking
        if (Input.GetKey(forwardKey))
        {
            movement += transform.forward;
            hasInput = true;
        }
        if (Input.GetKey(backKey))
        {
            movement += -transform.forward;
            hasInput = true;
        }
        if (Input.GetKey(rightKey))
        {
            movement += transform.right;
            hasInput = true;
        }
        if (Input.GetKey(leftKey))
        {
            movement += -transform.right;
            hasInput = true;
        }

        // Normalize to maintain consistent speed in diagonal movement
        if (hasInput)
        {
            movement = movement.normalized * walkingSpeed;
        }

        // Jumping
        if (jumpEnabled && Input.GetKey(jumpKey) && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }

        // Apply movement to rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    void Update()
    {
        if (crouchEnabled && Input.GetKeyDown(crouchKey))
        {
            // Crouching
            transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
        }
        else if (crouchEnabled && Input.GetKeyUp(crouchKey))
        {
            // Not crouching
            transform.localScale = new Vector3(transform.localScale.x, normalHeight, transform.localScale.z);
        }
    }

    // Check if player is on the ground
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f + transform.localScale.y);
    }
}
