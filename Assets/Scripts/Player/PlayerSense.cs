using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSense : MonoBehaviour
{
    public Linker mLinker;
    public bool isInteracting;
    GameObject interactedObj;

    void Start(){
        isInteracting = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Trigger"){
            mLinker.mStatusBalloon.SetActive(true);
            isInteracting = true;
            interactedObj = other.gameObject;
        }

        if(other.gameObject.tag == "Key"){
            mLinker.mInventory.AcquireKey();
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Trigger"){
            mLinker.mStatusBalloon.SetActive(false);
            isInteracting = false;
            interactedObj = null;
        }
    }

    public void Interact(){
        Debug.Log(interactedObj.name);
    }
}
