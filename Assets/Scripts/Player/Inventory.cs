using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Linker mLinker;
    bool isKeyAcquired;

    void Start(){
        isKeyAcquired = false;
    }

    public void AcquireKey(){
        isKeyAcquired = true;
        mLinker.mUIManager.ShowKeyIndicator(isKeyAcquired);
    }
}
