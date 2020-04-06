using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BombInteract : MonoBehaviour
{
    public GameObject WonPanel;
    public SpriteRenderer bomb;
    public Sprite Deactivated_bomb;

    void OnInteract(GameObject Caller)
    {
        if (DialogueManager.Instance.KilledRightPerson == DialogueTrigger.GuiltyPeopleCount)
        {
            Debug.Log(Caller.name + " Interact with " + name);
            bomb.sprite = Deactivated_bomb;

            Invoke("WinState", 1);
        }
        
    }

    private void WinState()
    {
        WonPanel.SetActive(true);
    }
}
