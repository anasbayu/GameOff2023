using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public Linker mLinker;
    public int speed;
    public int jumpPower;
    bool facingRight;           // direction indicator
    public bool isJumping;      // jumping indicator
    bool IsCrouching;
    bool isMoving;
    public bool onLand;         // Prevent jumping mid air.
    public GameObject indicator;
    public Vector2 lastPosition;
    public Animator mAnimator;
    Scene scene;

    void Start(){
        onLand = true;
        facingRight = true;
        isJumping = false;
        IsCrouching = false;
        isMoving = false;
        lastPosition = transform.position;
        scene = SceneManager.GetActiveScene();
    }

    void Update(){
        if(!mLinker.mVNManager.isShowingLore && !mLinker.mGameManager.isPaused){
            // Move right.
            if(Input.GetKey(KeyCode.D)){
                isMoving = true;
                transform.Translate(Vector2.right * speed * Time.deltaTime);

                float tmp = lastPosition.x - transform.position.x;

                // Check if Player moving/not.
                if(tmp < -0f){
                    lastPosition = transform.position;
                    mLinker.mParallaxManager.ParallaxingForward(true);
                    transform.hasChanged = false;
                }
                if(!facingRight){
                    Flip();
                }

                // Play the animation.
                if(IsCrouching){
                    mAnimator.SetBool("IsCrawling", true);
                }else{
                    mAnimator.SetBool("IsWalking", true);
                }

                // Play SFX.
                // mLinker.mSFX.PlaySFX("Walk");
            }

            if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
                if(IsCrouching){
                    mAnimator.SetBool("IsCrawling", false);
                }else{
                    mAnimator.SetBool("IsWalking", false);
                }
                isMoving = false;
            }


            // Move left.
            if(Input.GetKey(KeyCode.A)){
                isMoving = true;
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                
                float tmp = lastPosition.x - transform.position.x;

                // Check if Player moving/not.
                if(tmp > 0.01f){
                    lastPosition = transform.position;
                    mLinker.mParallaxManager.ParallaxingForward(false);
                    transform.hasChanged = false;
                }
                
                if(facingRight){
                    Flip();
                }

                // Play the animation.
                if(IsCrouching){
                    mAnimator.SetBool("IsCrawling", true);
                }else{
                    mAnimator.SetBool("IsWalking", true);
                }            

                // Play SFX.
                // mLinker.mSFX.PlaySFX("Walk");
            }

            // Jump.
            if(Input.GetKeyDown(KeyCode.Space) && onLand && !IsCrouching){
                if(!isJumping){
                    isJumping = true;
                    mAnimator.SetBool("IsJumping", true);
                }
            }

            // Crouch, available when you are a child.
            // if(Input.GetKeyDown(KeyCode.LeftControl) && onLand && !mLinker.mPlayerStatus.isAdultState){
            //     if(IsCrouching){
            //         mAnimator.SetBool("IsCrouching", false);
            //         speed += 3;
            //         IsCrouching = false;
            //     }else{
            //         mAnimator.SetBool("IsCrouching", true);
            //         speed -= 3;
            //         IsCrouching = true;
            //     }
            // }

            // Change self age.
            // if(Input.GetKeyDown(KeyCode.Q)){
            //     mLinker.mPlayerStatus.Transform();
            // }

            // Change environment age.
            if(Input.GetKeyDown(KeyCode.E) && scene.name != "Level 1"){
                mLinker.mEnvManager.SwitchEnvironmentState();
            }

            // Interact action.
            if(Input.GetKeyDown(KeyCode.F) && mLinker.mPlayerSense.isInteracting){
                mLinker.mPlayerSense.Interact();
            }

        }

        // Pause game.
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(mLinker.mGameManager.isPaused){
                mLinker.mGameManager.ResumeGame();
            }else{
                mLinker.mGameManager.PauseGame();
            }
        }
    }

    void FixedUpdate(){
        if(isJumping){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            onLand = false;
            isJumping = false;
            mLinker.mSFX.PlaySFX("Jump");
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

   public string GetDirection(){
        string returnVal = "idle";

        if(isMoving){
            if(facingRight){
                returnVal = "right";
            }else{
                returnVal = "left";
            }
        }

        return returnVal;
   }
}
