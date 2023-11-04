using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSense : MonoBehaviour
{
    public Linker mLinker;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Trigger"){
            mLinker.mStatusBalloon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Trigger"){
            mLinker.mStatusBalloon.SetActive(false);
        }
    }
}
