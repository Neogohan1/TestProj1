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
    
    public bool topTriggerOverlapping = false;


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

            
            if(Input.GetAxis("Vertical") < 0.0f && isGrounded) {
                //RaycastHit2D down = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 0.001f), 1 << LayerMask.NameToLayer("Platform"));

                if (topTriggerOverlapping) {
                    GetComponent<CapsuleCollider2D>().isTrigger = true;
                    //StartCoroutine("Fall");
                }
                
            }
            
        }
    }

    void Jump(){
        isGrounded = false;
        rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
    }

    private void Update() {
        if (isLocalPlayer) {
            if (Input.GetButtonDown("Jump") && isGrounded){
                Jump();
            }
        }
        

        

        //Debug.Log(down.ToString());



        

    }



    private void FixedUpdate() {
        HandleMovement();
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (rb.velocity.y == 0){
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "TopTrigger" && rb.velocity.y <= 0 ){
            topTriggerOverlapping = true;
            //Debug.Log("Enter top trigger with velocity " + rb.velocity.y);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "TopTrigger" && rb.velocity.y < 0){
            topTriggerOverlapping = false;
            //Debug.Log("Exit top trigger with velocity " + rb.velocity.y);
        }
    }


    private IEnumerator Fall() {
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0);
        //yield return new WaitForSeconds(0.3f);
        //GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
    


}
