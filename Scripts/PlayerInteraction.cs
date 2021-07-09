using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    Dialogue dialogue;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetButtonDown("Interact"))
        {
            Debug.Log ("apertouoenter");
            if(collision.gameObject.tag == "dialogue")
            {
                dialogue = collision.gameObject.GetComponent<Dialogue>();
                dialogue.Interact();
            }
        }
    }
}
