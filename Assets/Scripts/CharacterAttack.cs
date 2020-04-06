using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public KeyCode StabKey = KeyCode.K;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(StabKey))
        {
            anim.SetTrigger("Stab");
        }
    }
}
