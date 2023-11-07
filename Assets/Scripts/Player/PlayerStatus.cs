using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour{
   public Linker mLinker;
   bool isAdultState;
   Animator mAnimator;

   void Start(){
        isAdultState = true;
        mAnimator = GetComponent<Animator>();
        mAnimator.SetBool("IsAdultState", isAdultState);
   }

   public void Transform(string mode){
        if(mode == "self"){
            if(isAdultState){
                isAdultState = false;
                mLinker.mUIManager.ChangeUIPlayerStatus(isAdultState);
                mAnimator.SetBool("IsAdultState", isAdultState);
                Debug.Log("into a kid!");
            }else{
                isAdultState = true;
                mLinker.mUIManager.ChangeUIPlayerStatus(isAdultState);
                mAnimator.SetBool("IsAdultState", isAdultState);
                Debug.Log("into an adult!");
            }
        }else{
            Debug.Log("transform environment!");
        }
   }
}
