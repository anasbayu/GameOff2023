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
        string triggerName = interactedObj.GetComponent<TriggerInfo>().triggerName;

        if(triggerName == "Ladder"){
            // StartCoroutine(Climb(interactedObj.GetComponent<Ladder>().GetDestinationPos()));
            mLinker.mPlayer.transform.position = interactedObj.GetComponent<Ladder>().GetDestinationPos();
        }else if(triggerName == "Lore"){
            interactedObj.GetComponent<Lore>().TellTheLore();
        }

        Debug.Log(interactedObj.GetComponent<TriggerInfo>().triggerName);
    }

    IEnumerator Climb(Vector2 destination){
        Vector2 currPlayerPos = mLinker.mPlayer.transform.position;

        // TODO: Broken code. This make the game freeze.
        while(currPlayerPos != destination){
            // Vector2.Lerp(mLinker.mPlayer.transform.position, destination, 1f * Time.deltaTime);
        }

        yield return new WaitForSeconds(1);
    }
}
