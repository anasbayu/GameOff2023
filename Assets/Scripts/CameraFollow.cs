using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public Linker mLinker;
    public float yOffset = -1;
    public float xOffset;
    public float followSpeed;
    public bool isActive;
    public GameObject boundaries;

    void Update(){
        if(isActive){
            string direction = mLinker.mPlayerControll.GetDirection();
            if(direction == "right"){
                xOffset = 3;
            }else if(direction == "left"){
                xOffset = -3;
            }else{
                xOffset = 0;
            }

            Transform playerTransform = mLinker.mPlayer.transform;
            Vector3 newPos = new Vector3(playerTransform.position.x + xOffset, playerTransform.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }

    public void Follow(Vector3 destination){
        Vector3 newPos = new Vector3(destination.x, destination.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
