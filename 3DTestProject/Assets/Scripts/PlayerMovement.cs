using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    void Update() {
        //Input
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        //Multiply by speed to determine how fast the player should be moving
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate() {
        //Set the players velocity so the player can move
        rb.velocity = moveVelocity;
    }
}
