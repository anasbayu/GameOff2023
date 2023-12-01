using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMeta : MonoBehaviour
{
    public Sprite mPrimeSprite, mRuinedSprite;
    
    public bool hideOnRuinedState;
    public bool hideOnPrimeState;
    public SpriteRenderer mSpriteRenderer;

    void Awake(){
        mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SwapSprite(bool isPrime){
        if(mSpriteRenderer == null){
            mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        if(isPrime){
            mSpriteRenderer.sprite = mRuinedSprite;
        }else{
            mSpriteRenderer.sprite = mPrimeSprite;
        }
    }

}
