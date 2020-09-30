using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//PURPOSE: character controller with basic movements and jumping
//USAGE: put this on an object with 2D collider and 2D rigidbody
public class PlayerControl : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    float inputHorizontal;
    bool isJumping;
    public float moveSpeed = 15f;
    public float jumpForce = 10f;
    public bool isGrounded; //set by PlatformGroundedTrigger.cs
    private bool facingRight = true;
    private bool doubleJump = false;

    private int extraJumps;
    public int extraJumpValues; //for double jumps
     public GameObject potion;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValues;
    }

    //happens every RENDERING frame, this is also where input happens
    void Update()
    {
        //Left/right arrow keys to move
        inputHorizontal = Input.GetAxis("Horizontal"); //Gets a value from -1 to 1. -1 if left, 1 if right.

        //Press SPACE to jump
        if (Input.GetButtonDown("Jump") && isGrounded == true && doubleJump == false){
            isJumping = true;
        }
        //double jump
        if(isGrounded == true){
            extraJumps = extraJumpValues;

        }
        if(Input.GetButtonDown("Jump") && extraJumps > 0 && doubleJump == true){
            isJumping = true;
            extraJumps --;
        }else if (Input.GetButtonDown("Jump") && isGrounded == true && extraJumps == 0 && doubleJump == true){
            isJumping = true;
        }

        
    }

    //happpens every PHYSICS frame, at a fixed time stamp
    void FixedUpdate(){
        //need to put the Y value back into itself to preserve verticle value (e.g. falling)
        myRigidbody.velocity = new Vector2(inputHorizontal*moveSpeed, myRigidbody.velocity.y);

        //if we need to jump, add Y velocity
        if(isJumping){
            myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
            isJumping = false;
        }

        //flic character
        if(facingRight == false && inputHorizontal > 0){
            Flip();
        } else if (facingRight == true && inputHorizontal < 0){
            Flip();
        }
    }

    //flip the character when facing different direction
    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Enemy"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.tag == "Potion"){
            doubleJump = true;
            potion.SetActive(false);
        }

    }


}
