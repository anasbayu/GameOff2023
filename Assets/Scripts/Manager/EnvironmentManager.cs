using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour{
    public Linker mLinker;
    public bool isPrimeState;       // true = in the past, false = present time

    public List<ObjectMeta> mSwitchableObjs = new List<ObjectMeta>();       // List of all game object that can be time switched.
   
    void Start(){
        isPrimeState = true;        // default true because the default is present time, and we change the value in SwitchEnvironmetState()

        SwitchEnvironmentState();
    }

    public void SwitchEnvironmentState(){
        isPrimeState = !isPrimeState;

        // Play VFX.
        

        foreach(ObjectMeta obj in mSwitchableObjs){
            obj.SwapSprite(isPrimeState);

            if(isPrimeState){
                obj.gameObject.SetActive(!obj.hideOnPrimeState);
            }else{
                obj.gameObject.SetActive(!obj.hideOnRuinedState);
            }
        }
    }
}
