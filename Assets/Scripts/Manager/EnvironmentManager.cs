using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour{
    public Linker mLinker;
    public bool isPrimeState = false;       // true = in the past, false = present time
    // public UnityEngine.Rendering.Universal.Light2D mGlobalLight;
    public List<UnityEngine.Rendering.Universal.Light2D> mLights;

    public List<ObjectMeta> mSwitchableObjs = new List<ObjectMeta>();       // List of all game object that can be time switched.
   
    void Start(){
        isPrimeState = false;        // default false because the default is present time, and we change the value in SwitchEnvironmetState()

        foreach(ObjectMeta obj in mSwitchableObjs){
            if(isPrimeState){
                obj.gameObject.SetActive(!obj.hideOnRuinedState);
            }else{
                obj.gameObject.SetActive(!obj.hideOnPrimeState);
            }
        }
    }

    public void SwitchEnvironmentState(){
        // Play VFX.
        mLinker.mEffectScreenFade.FadeToBlack();
    }

    public void Switch(){
        foreach(ObjectMeta obj in mSwitchableObjs){
            obj.SwapSprite(isPrimeState);

            if(isPrimeState){
                obj.gameObject.SetActive(!obj.hideOnRuinedState);
            }else{
                obj.gameObject.SetActive(!obj.hideOnPrimeState);
            }
        }

        isPrimeState = !isPrimeState;

        // Change glogal light color.
        string ruinedColor = "#C4BFFF";
        string primeColor = "#FFF6BF";
        string colorHex;
        if(isPrimeState){
            colorHex = primeColor;
        }else{
            colorHex = ruinedColor;
        }

        ColorUtility.TryParseHtmlString(colorHex , out Color tmpColor);

        foreach(UnityEngine.Rendering.Universal.Light2D light in mLights){
            light.color = tmpColor;

            // Hide light on sieged walls on prime state.
            if(light.gameObject.name == "Light Sieged" && isPrimeState){
                light.gameObject.SetActive(false);
            }else{
                light.gameObject.SetActive(true);
            }
        }
        mLinker.mEffectScreenFade.FadeToNormal();
    }
}
