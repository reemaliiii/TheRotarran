using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHandle : MonoBehaviour
{
    void OnInteract(GameObject Caller)
    {
        Debug.Log(Caller.name + " Interact with " + name);
        GameManager.instace.OpenBox();

    }

}
