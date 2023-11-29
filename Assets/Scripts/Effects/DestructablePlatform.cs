using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructablePlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "Rock"){
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 9f;
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
