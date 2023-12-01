using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image overlayBlack;
    public Animator mAnimator;

    public void FadeToBlack(){
        Debug.Log("fadee");
        mAnimator.SetBool("IsFading", true);
    }

    public void FadeToNormal(){
        mAnimator.SetBool("IsFading", false);
    }
}
