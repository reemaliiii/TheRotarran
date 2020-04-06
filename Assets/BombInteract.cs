using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BombInteract : MonoBehaviour
{
    public SpriteRenderer bomb;
    public Sprite Deactivated_bomb;
    void OnInteract(GameObject Caller)
    {

        Debug.Log(Caller.name + " Interact with " + name);
        bomb.sprite = Deactivated_bomb; 
    }
}
