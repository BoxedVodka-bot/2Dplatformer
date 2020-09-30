using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger1 : MonoBehaviour
{
    //when step on the button, the door opens
   public GameObject door;
   public GameObject message;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            door.SetActive(false);
            message.SetActive(true);
        }
    }
}
