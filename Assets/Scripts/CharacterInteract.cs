using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    public KeyCode InteractKey = KeyCode.E;
    public string InteractionTag = "Interactable";

    bool inTrigger;
    GameObject col;
    private void Update() {
        if (inTrigger && col && Input.GetKeyDown(InteractKey)) {
            col.BroadcastMessage("OnInteract", gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == InteractionTag) {
            inTrigger = true;
            col = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == InteractionTag) {
            inTrigger = false;
            col = null;
        }
    }
}
