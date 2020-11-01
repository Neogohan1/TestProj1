using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject player;

    private void Start() {
        player = gameObject.transform.parent.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Terrain"){
            player.GetComponent<Player>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Terrain"){
            player.GetComponent<Player>().isGrounded = false;
        }
    }
}
