using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public static int InnocentPeopleCount = 0;
    public static int GuiltyPeopleCount = 0;
    public static int InteractPeopleBeforeCount = 0;

    public Dialogue dialogue;
    public Dialogue altDialog;
    public int NextDoor;
    public bool ShouldKill;
    public bool ShouldInteractBeforeBoss;

    public bool ShowKillDialogue = false;
    public bool IsBoss = false;

    private void Start()
    {
        if (!ShouldKill)
            InnocentPeopleCount++;
        else
            GuiltyPeopleCount++;
        if (ShouldInteractBeforeBoss)
        {
            InteractPeopleBeforeCount++;
        }
    }

    public void TriggerDialogue()
    {
        var dialogManager = DialogueManager.Instance;
        Debug.Log("KilledWrongPerson: " + dialogManager.KilledWrongPerson + " KilledRightPerson: " + dialogManager.KilledRightPerson);
        if (IsBoss)
        {
            var tmDialog = new Dialogue();
            if (dialogManager.KilledWrongPerson == 0 && dialogManager.KilledRightPerson == 0)
            {

                //tmDialog.sentences = new string[] {
                //    "No blood?! The guilty is alive? Guilty people should be banished!",
                //    "Kill the guilty person!"
                //};
                dialogManager.StartDialogue(altDialog, NextDoor, ShowKillDialogue, ShouldKill, true);
            }
            else if (dialogManager.KilledWrongPerson > 0)
            {
                //tmDialog.sentences = new string[] {
                //    "You are savage! You made it even worse...",
                //    "You have killed innocent people...",
                //    "Or wait?! Who gave you the right to kill...",
                //};
                dialogManager.StartDialogue(dialogue, NextDoor, ShowKillDialogue, ShouldKill, true);
            }
            else if (dialogManager.KilledRightPerson != GuiltyPeopleCount)
            {
                tmDialog.sentences = new string[] {
                    "Some guilty are still alive? Guilty people should be banished!",
                    "Kill the guilty person!"
                };
                dialogManager.StartDialogue(tmDialog, NextDoor, ShowKillDialogue, ShouldKill, true);
            }
            else if (dialogManager.KilledRightPerson == GuiltyPeopleCount) // won't happen here
            {
                GameManager.instace.ShowBombTable();
            }
            else
            {

            }
        }
        else
        {
            if (ShouldInteractBeforeBoss)
            {
                dialogManager.SpokenTo.Add(transform);
            }
            dialogManager.StartDialogue(dialogue, NextDoor, ShowKillDialogue, ShouldKill);
        }

        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue, NextDoor, ShowKillDialogue, ShouldKill);
    }

    void OnInteract(GameObject Caller)
    {
        if (DialogueManager.Instance.InDialogue)
            return;
        Debug.Log(Caller.name + " Interact with " + name);
        TriggerDialogue();

    }
}
