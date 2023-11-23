using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public Linker mLinker;
    public float yOffset = -1;
    public float followSpeed;
    public bool isActive;

    void Update(){
        if(isActive){
            // TODO: make camera move like hollow knight.
            Transform playerTransform = mLinker.mPlayer.transform;
            Vector3 newPos = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }

    public void Follow(Vector3 destination){
        Vector3 newPos = new Vector3(destination.x, destination.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
