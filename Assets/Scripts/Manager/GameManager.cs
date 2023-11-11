using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Linker mLinker;
    public bool isPaused;

    void Start(){
        isPaused = false;
    }

    public void PauseGame(){
        mLinker.mUIManager.ShowMenu();
        isPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        mLinker.mUIManager.HideMenu();
        isPaused = false;
        Time.timeScale = 1;
    }
}
