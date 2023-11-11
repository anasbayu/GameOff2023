using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VNManager : MonoBehaviour
{
    public GameObject imgLeft, imgRight;
    public GameObject textBox;
    public TMP_Text txtStory;
    // public SceneLoader mSceneLoader;
    int currStoryDisplayedIndex = 0;
    bool isTextScrolling = false;
    public bool isShowingLore;

    [SerializeField] private float scrolingSpeed = 0.05f;

    private string[] stories;
    private Sprite[] leftImages;  // NOTE: Panjang harus sama dengan story, kalau ga err.
    private Sprite[] rightImages; 
    Image imgLeftRenderer, imgRightRenderer;


    void Start(){
        isShowingLore = false;

        imgLeftRenderer = imgLeft.GetComponent<Image>();
        imgRightRenderer = imgRight.GetComponent<Image>();
    }

    void Update(){
        if(Input.GetKey(KeyCode.F) && !isTextScrolling && isShowingLore){
            if(currStoryDisplayedIndex < stories.Length){
                StartCoroutine(AnimateText(currStoryDisplayedIndex));
            }else{
                HideVNComponent();
                // End of the story. Resume gameplay.
                // mSceneLoader.ChangeScene("Gameplay");
            }
        }

        // if(Input.GetKeyDown(KeyCode.S)){
        //     txtStory.text = stories[currStoryDisplayedIndex];
        //     UpdateImage(currStoryDisplayedIndex);
        //     imgLeft.SetActive(leftImages[currStoryDisplayedIndex]);
        //     imgRight.SetActive(rightImages[currStoryDisplayedIndex]);
            
        //     isTextScrolling = false;
        //     currStoryDisplayedIndex++;
        //     StopAllCoroutines();


        //     // TODO: Why is this not!!!!?
        //     if(currStoryDisplayedIndex >= stories.Length){
        //         HideVNComponent();
        //         // mSceneLoader.ChangeScene("Gameplay");
        //     }
        // }
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

        imgLeft.SetActive(leftImages[index]);
        imgRight.SetActive(rightImages[index]);

        for(int i = 0; i < stories[index].Length + 1; i++){
            txtStory.text = stories[index].Substring(0, i);
            yield return new WaitForSeconds(scrolingSpeed);
        }

        isTextScrolling = false;
        currStoryDisplayedIndex++;
        Debug.Log("curr index: " + currStoryDisplayedIndex);
    }

    void UpdateImage(int index){
        if(leftImages[index] != null){
            imgLeftRenderer.sprite = leftImages[index];
        }
        if(rightImages[index] != null){
            imgRightRenderer.sprite = rightImages[index];
        }
    }

    public void TellTheLore(string[] loreToTell, Sprite[] leftImagesToShow, Sprite[] rightImagesToShow){
        isShowingLore = true;
        stories = loreToTell;
        leftImages = leftImagesToShow;
        rightImages = rightImagesToShow;

        textBox.SetActive(true);

        Debug.Log("curr indexa: " + currStoryDisplayedIndex);
        Debug.Log("story length: " + stories.Length);

        StartCoroutine(AnimateText(currStoryDisplayedIndex));
    }

    void HideVNComponent(){
        currStoryDisplayedIndex = 0;
        isShowingLore = false;

        textBox.SetActive(false);
        imgLeft.SetActive(false);
        imgRight.SetActive(false);
        gameObject.SetActive(false);
    }
}
