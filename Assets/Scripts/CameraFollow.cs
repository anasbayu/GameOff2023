using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Linker mLinker;
    public float yOffset = -1;
    public float followSpeed;
    // Vector3 initialPos;

    // void Start(){
    //     initialPos = transform.position;
    // }


    void Update(){
        Transform playerTransform = mLinker.mPlayer.transform;
        Vector3 newPos = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    

        // if(initialPos.x > transform.position.x){
        //     Debug.Log(initialPos.x);
        //     mLinker.mParallaxManager.ParallaxingForward(true);
        //     initialPos = transform.position;
        // }
        // else if(initialPos.x < transform.position.x){
        //     mLinker.mParallaxManager.ParallaxingForward(false);
        //     initialPos = transform.position;
        // }
    }
}
