using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger1 : MonoBehaviour
{
   //Step on button and the clue appears
    public GameObject clue;
    public GameObject wall;
    public GameObject arrow;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            clue.SetActive(true);
            wall.SetActive(false);
            arrow.SetActive(false);
        }
    }
}
