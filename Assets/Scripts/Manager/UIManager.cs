using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{
    public Linker mLinker;
    public Image mUIPlayerStatus;
    public GameObject mUIKeyIndicator;
    public GameObject mMenuPaused, mLevelComplete;

    void Start(){
        ChangeUIPlayerStatus(mLinker.mPlayerStatus.isAdultState);
    }

    public void ChangeUIPlayerStatus(bool isAdultState){
        if(isAdultState){
            mUIPlayerStatus.color = Color.red;
        }else{
            mUIPlayerStatus.color = Color.blue;
        }
    }

    public void ShowKeyIndicator(bool isShowing){
        mUIKeyIndicator.SetActive(isShowing);
    }

    public void ShowMenu(){
        mMenuPaused.SetActive(true);
    }

    public void HideMenu(){
        mMenuPaused.SetActive(false);
    }

    public void ShowLevelComplete(){
        mLevelComplete.SetActive(true);
    }

    public void HideLevelComplete(){
        mLevelComplete.SetActive(false);
    }
}
