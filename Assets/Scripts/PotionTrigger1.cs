using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTrigger1 : MonoBehaviour
{
     //When step on the button, potion drops and clue appears
   public GameObject jump;
   public GameObject potion;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            jump.SetActive(true);
            potion.SetActive(true);
        }
    }
}
