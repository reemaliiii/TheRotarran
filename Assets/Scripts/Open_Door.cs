using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Door : MonoBehaviour
{

    /*void OnInteract(GameObject Caller)
    {
        
    }*/
    public Animator m_Animator;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {

            if(Input.GetKeyDown(KeyCode.T))
            {
                m_Animator.SetBool("IsOpen", true);
            }
        }
    }
}
