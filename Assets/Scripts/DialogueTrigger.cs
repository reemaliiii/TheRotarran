using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public int NextDoor;
    public bool ShouldKill;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, NextDoor, ShouldKill);

    }

    void OnInteract(GameObject Caller)
    {
        if (DialogueManager.Instance.InDialogue)
            return;
        Debug.Log(Caller.name + " Interact with " + name);
        TriggerDialogue();

    }
}
