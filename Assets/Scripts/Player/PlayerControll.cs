using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Linker mLinker;
    int speed = 10;
    public int jumpPower;
    bool facingRight;           // direction indicator
    public bool isJumping;      // jumping indicator
    public bool onLand;         // Prevent jumping mid air.

    void Start(){
        onLand = true;
        facingRight = true;
        isJumping = false;
    }

    void Update(){
        // Move right.
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            mLinker.mParallaxManager.ParallaxingForward(true);
            if(!facingRight){
                Flip();
            }
        }

        // Move left.
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            mLinker.mParallaxManager.ParallaxingForward(false);

            if(facingRight){
                Flip();
            }
        }

        // Jump.
        if(Input.GetKeyDown(KeyCode.Space) && onLand){
            if(!isJumping){
                isJumping = true;
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
   }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Land"){
            onLand = true;
        }
   }
}