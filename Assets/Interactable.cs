using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    void OnInteract()
    {
        Debug.Log("Interact with" + name);
    }
}
