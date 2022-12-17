using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public MenuController mc;

    void Update() {
        if(mc.pause == false) {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;
        }
    }

    void FixedUpdate() {
        if(mc.pause == false) {
            rb.velocity = moveVelocity;
        }
    }
}
