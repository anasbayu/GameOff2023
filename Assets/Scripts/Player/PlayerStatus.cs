using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour{
   public Linker mLinker;
   bool isAdultState;
   Animator mAnimator;

   void Start(){
        isAdultState = false;
        mAnimator = GetComponent<Animator>();
        mAnimator.SetBool("IsAdultState", isAdultState);
   }

   public void Transform(string mode){
        if(mode == "self"){
            if(isAdultState){
                isAdultState = false;
                mLinker.mUIManager.ChangeUIPlayerStatus(isAdultState);
                mLinker.mPlayer.transform.localScale /= 1.3f;
                mLinker.mPlayerControll.SetJumpPower("Kid");
                // mAnimator.SetBool("IsAdultState", isAdultState);
                Debug.Log("into a kid!");
            }else{
                isAdultState = true;
                mLinker.mUIManager.ChangeUIPlayerStatus(isAdultState);
                mLinker.mPlayer.transform.localScale *= 1.3f;
                mLinker.mPlayerControll.SetJumpPower("Adult");
                // mAnimator.SetBool("IsAdultState", isAdultState);
                Debug.Log("into an adult!");
            }
        }else{
            Debug.Log("transform environment!");
        }
   }

   public bool GetBodyState(){
        return isAdultState;
   }
}
