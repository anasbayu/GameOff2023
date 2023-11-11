using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Linker mLinker;
    public int speed;
    public int jumpPower;
    bool facingRight;           // direction indicator
    public bool isJumping;      // jumping indicator
    public bool onLand;         // Prevent jumping mid air.
    public GameObject indicator;
    public Vector2 currPosition;
    public Animator mAnimator;

    void Start(){
        onLand = true;
        facingRight = true;
        isJumping = false;
        currPosition = transform.position;
    }

    void Update(){
        if(!mLinker.mVNManager.isShowingLore){
            // Move right.
            if(Input.GetKey(KeyCode.D)){
                transform.Translate(Vector2.right * speed * Time.deltaTime);

                if(!Mathf.Approximately(currPosition.x, transform.position.x)){
                    // Debug.Log(currPosition.x - transform.position.x);
                // if(Mathf.RoundToInt(currPosition.x) != Mathf.RoundToInt(transform.position.x)){
                    currPosition = transform.position;
                    mLinker.mParallaxManager.ParallaxingForward(true);
                }
                if(!facingRight){
                    Flip();
                }

                // Play the animation.
                mAnimator.SetBool("IsWalking", true);
            }

            if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
                mAnimator.SetBool("IsWalking", false);
            }


            // Move left.
            if(Input.GetKey(KeyCode.A)){
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                if(!Mathf.Approximately(currPosition.x, transform.position.x)){
                // if(Mathf.RoundToInt(currPosition.x) != Mathf.RoundToInt(transform.position.x)){
                    currPosition = transform.position;          
                    mLinker.mParallaxManager.ParallaxingForward(false);
                }

                if(facingRight){
                    Flip();
                }

                // Play the animation.
                mAnimator.SetBool("IsWalking", true);
            }

            // Jump.
            if(Input.GetKeyDown(KeyCode.Space) && onLand){
                if(!isJumping){
                    isJumping = true;
                    mAnimator.SetBool("IsJumping", true);
                }
            }

            // Change self age.
            if(Input.GetKeyDown(KeyCode.Q)){
                mLinker.mPlayerStatus.Transform("self");
            }

            // Change environment age.
            if(Input.GetKeyDown(KeyCode.E)){
                mLinker.mPlayerStatus.Transform("environment");
            }

            // Interact action
            if(Input.GetKeyDown(KeyCode.F) && mLinker.mPlayerSense.isInteracting){
                mLinker.mPlayerSense.Interact();
            }
        }
    }

    void FixedUpdate(){
        if(isJumping){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            onLand = false;
            isJumping = false;
        }
    }

    private void Flip(){
       //Switch the way the player is labelled as facing.
       facingRight = !facingRight;
 
       //Multiply the player's x local scale by -1.
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;

       Vector3 indicatorScale = indicator.transform.localScale;
       indicatorScale.x *= -1;
       indicator.transform.localScale = indicatorScale;
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Land"){
            onLand = true;
            mAnimator.SetBool("IsJumping", false);
        }
   }

   public void SetJumpPower(string mode){
        if(mode == "Kid"){
            jumpPower = 23;
        }else{
            jumpPower = 30;
        }
   }
}
