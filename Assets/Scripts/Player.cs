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

    CapsuleCollider2D playerCollider2d;

    EdgeCollider2D groundCheckEdge;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        playerCollider2d = GetComponent<CapsuleCollider2D>();
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

        //RaycastHit2D down = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 0.1f), 1 << LayerMask.NameToLayer("Platform"));

        //Debug.Log(down.ToString());



        if(Input.GetAxis("Vertical") < 0.0f) {
            StartCoroutine("Fall");
        }

    }



    private void FixedUpdate() {
        HandleMovement();
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (rb.velocity.y == 0){
            isGrounded = true;
        }
    }


    private IEnumerator Fall() {
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
    


}
