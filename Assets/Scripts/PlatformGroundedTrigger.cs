using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGroundedTrigger : MonoBehaviour
{   
    public PlayerControl player; //public, assign in inspector

    //happens every frame there's an object inside the trigger area
    void OnTriggerStay2D(Collider2D activator){
        player.isGrounded = true;
    }
    //happens the first frame where an object leaves the trigger area
    void OnTriggerExit2D(Collider2D activator){
        player.isGrounded = false;
    }
}
