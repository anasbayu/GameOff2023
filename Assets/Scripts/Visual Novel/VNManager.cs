using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VNManager : MonoBehaviour
{
    public GameObject imgLeft, imgRight;
    public GameObject textBox;
    public TMP_Text txtStory;
    // public SceneLoader mSceneLoader;
    int currStoryDisplayedIndex = 0;
    bool isTextScrolling = false;


    [Header("Story Config")]
    [SerializeField] [TextArea] private string[] stories;
    // [SerializeField] private 
    [SerializeField] private float scrolingSpeed = 0.05f;
    [SerializeField] private bool[] showLeftImage;  // NOTE: Panjang harus sama dengan story, kalau ga err.
    [SerializeField] private bool[] showRightImage; // NOTE: Panjang harus sama dengan story, kalau ga err.
    [SerializeField] private Sprite[] expressionList; // NOTE: Panjang harus sama dengan story, kalau ga err.


    public SpriteRenderer imgLeftRenderer, imgRightRenderer;

    void Start(){
        StartCoroutine(AnimateText(currStoryDisplayedIndex));
    }

    void Update(){
        if(Input.GetKey(KeyCode.Space) && !isTextScrolling){
            if(currStoryDisplayedIndex < stories.Length){
                StartCoroutine(AnimateText(currStoryDisplayedIndex));
            }else{
                // Story habis, ganti scene ke Gameplay.
                // mSceneLoader.ChangeScene("Gameplay");
            }
        }

        if(Input.GetKeyDown(KeyCode.S)){
            txtStory.text = stories[currStoryDisplayedIndex];
            UpdateImage(currStoryDisplayedIndex);
            imgLeft.SetActive(showLeftImage[currStoryDisplayedIndex]);
            imgRight.SetActive(showRightImage[currStoryDisplayedIndex]);
            
            isTextScrolling = false;
            currStoryDisplayedIndex++;
            StopAllCoroutines();

            if(currStoryDisplayedIndex >= stories.Length){
                // mSceneLoader.ChangeScene("Gameplay");
            }
        }
    }

    void ShowImage(string position){
        if(position == "left"){
            imgLeft.SetActive(true);
        }else{
            imgRight.SetActive(true);
        }
    }
    
    void HideImage(string position){
        if(position == "left"){
            imgLeft.SetActive(false);
        }else{
            imgRight.SetActive(false);
        }
    }

    IEnumerator AnimateText(int index){
        isTextScrolling = true;
        UpdateImage(index);

        imgLeft.SetActive(showLeftImage[index]);
        imgRight.SetActive(showRightImage[index]);

        for(int i = 0; i < stories[index].Length + 1; i++){
            txtStory.text = stories[index].Substring(0, i);
            yield return new WaitForSeconds(scrolingSpeed);
        }

        isTextScrolling = false;
        currStoryDisplayedIndex++;
    }

    void UpdateImage(int index){
        if(expressionList[index] != null){
            imgLeftRenderer.sprite = expressionList[index];
            imgRightRenderer.sprite = expressionList[index];
        }
    }
}
