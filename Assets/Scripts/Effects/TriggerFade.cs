using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFade : MonoBehaviour
{
    public Linker mLinker;

    public void AnimationTriggerEnd(){
        mLinker.mEnvManager.Switch();
    }
}
