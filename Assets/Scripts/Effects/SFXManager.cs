using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour{
    public AudioClip mJump, mWalk, mPickup, mDoorUnlock;
    public AudioSource mAudioSource, mAudioSourceWalk;

    public void PlaySFX(string sfx){
        if(sfx == "Jump"){
            mAudioSource.clip = mJump;
        }else if(sfx == "Door Unlock"){
            mAudioSource.clip = mDoorUnlock;
        }else if(sfx == "Pickup"){
            mAudioSource.clip = mPickup;
        }
        
        if(sfx == "Walk"){
            mAudioSourceWalk.clip = mWalk;
            mAudioSourceWalk.Play();
        }

        mAudioSource.Play();
    }
}
