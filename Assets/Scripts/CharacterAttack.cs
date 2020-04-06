using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public KeyCode StabKey = KeyCode.K;
    public GameObject InteractionText;

    Animator anim;

    DialogueTrigger chr;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(StabKey))
        {
            anim.SetTrigger("Stab");
            if (chr)
            {
                //print(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
                string currClipName = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
                var CharPos = chr.transform.position;
                var DirToChar = transform.position - CharPos;
                Vector2 myDir = Vector2.zero;

                if (currClipName.Contains("Side2"))
                {
                    myDir = Vector2.right;
                }
                else
                {
                    myDir = Vector2.left;
                }

                //print(myDir);
                //print(DirToChar);
                var angle = Mathf.Abs(Vector2.Angle(DirToChar, myDir));

                //print(angle);

                if (angle > 150)
                {
                    DialogueManager.Instance.OnKillButtonClick(chr.transform);
                    chr.tag = "Untagged";
                    InteractionText.SetActive(false);
                    //chr.gameObject.SetActive(false);
                }
                chr = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            chr = collision.GetComponent<DialogueTrigger>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            chr = null;
        }
    }
}
