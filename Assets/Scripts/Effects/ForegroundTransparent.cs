using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundTransparent : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.85f);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
    
}
