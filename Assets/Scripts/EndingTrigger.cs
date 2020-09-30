using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    // when player touches the ending character, finale appears.
    public GameObject fin;
    public GameObject smile;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            fin.SetActive(true);
            smile.SetActive(true);
        }
    }
}
