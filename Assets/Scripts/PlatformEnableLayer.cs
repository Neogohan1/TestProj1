using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnableLayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && other.GetComponent<Rigidbody2D>().velocity.y < 0) {
            other.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }
}
