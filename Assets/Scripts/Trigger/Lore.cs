using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lore : TriggerInfo{
    public Linker mLinker;

    [Header("Story Config")]
    [SerializeField] [TextArea] private string[] stories;
    // NOTE: Panjang harus sama dengan story, kalau ga err.
    [SerializeField] private Sprite[] leftImages;  // NOTE: Panjang harus sama dengan story, kalau ga err.
    [SerializeField] private Sprite[] rightImages; // NOTE: Panjang harus sama dengan story, kalau ga err.


    public void TellTheLore(){
        mLinker.mVNManager.gameObject.SetActive(true);
        mLinker.mVNManager.TellTheLore(stories, leftImages, rightImages);
    }
    
}
