using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    void OnInteract(GameObject Caller)
    {
        Debug.Log(Caller.name + " Interact with " + name);
    }

}
