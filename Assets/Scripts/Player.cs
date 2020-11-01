using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Player : NetworkBehaviour
{

    public float moveSpeed = 5;
    public float jumpForce = 6;
    public bool isGrounded = false;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void HandleMovement(){
        if (isLocalPlayer){
            float moveHorizontal = Input.GetAxis("Horizontal");
            //Vector3 movement = new Vector3(0.1f * moveHorizontal, moveVertical * 0.1f, 0);
            if (moveHorizontal > 0) {
                //rb.AddForce(new Vector2(Math.Abs(moveHorizontal)*moveSpeed,0),ForceMode2D.Force);
                rb.velocity = new Vector2(Math.Abs(moveHorizontal)*moveSpeed,rb.velocity.y);
            } else if (moveHorizontal < 0){
                //rb.AddForce(new Vector2(-Math.Abs(moveHorizontal)*moveSpeed,0),ForceMode2D.Force);
                rb.velocity = new Vector2(Math.Abs(moveHorizontal)*-moveSpeed,rb.velocity.y);
            } else {
                //rb.velocity = new Vector2(0,rb.velocity.y);
            }
            //transform.position = transform.position + movement;
        }
    }

    void Jump(){
        isGrounded = false;
        rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
    }

    private void Update() {
        if (Input.GetButtonDown("Jump") && isGrounded){
            Jump();
        }



    }

    private void FixedUpdate() {
        HandleMovement();
        
    }
    


}
