using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMeta : MonoBehaviour
{
    public Sprite mPrimeSprite, mRuinedSprite;
    
    public bool hideOnRuinedState;
    public bool hideOnPrimeState;
    SpriteRenderer mSpriteRenderer;

    void Start(){
        mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SwapSprite(bool isPrime){
        if(isPrime){
            mSpriteRenderer.sprite = mRuinedSprite;
        }else{
            mSpriteRenderer.sprite = mPrimeSprite;
        }
    }

}
