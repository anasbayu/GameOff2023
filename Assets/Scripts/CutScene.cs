using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour{
    public Linker mLinker;

    public Transform pointA, pointB;

    public void PlayCutscene(){
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.H)){
            if(!mLinker.mCamera.isActive){
                mLinker.mCamera.Follow(pointB.position);
            }
        }
    }
}
