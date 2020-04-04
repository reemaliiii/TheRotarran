using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    DialogueTrigger DT;
    public float movementSpeed = 10;
    private GameObject Character;
    public GameObject InteractionText;
    // counter to stop the bug where you can reset the dialogue even before finishing it.
    private int cnt = 1;

    public float Speed;
    public AudioClip BossFight;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Interactable")
        {
            InteractionText.SetActive(true);
        }

        if(collision.transform.tag =="BossRoom")
        {
            Camera.main.GetComponent<CameraMovement>().DownClamp = 13.5f;
            Camera.main.GetComponent<CameraMovement>().TopClamp = 13.5f;
            Camera.main.GetComponent<CameraMovement>().RightClamp = 0;
            Camera.main.GetComponent<CameraMovement>().LeftClamp = 0;
            Camera.main.GetComponent<AudioSource>().Stop();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(BossFight);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "Char" && Input.GetKeyDown(KeyCode.T) && cnt == 1)
    //    {
    //        Character = collision.gameObject;
    //        Debug.Log("convo started");
    //        Character.GetComponent<DialogueTrigger>().TriggerDialogue();
    //        cnt = 0;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Interactable")
        {
            InteractionText.SetActive(false);
            cnt = 1;
        }
    }
    void FixedUpdate()
    {
        if (!DialogueManager.Instance.InDialogue)
        {
            Vector2 mov = Vector2.zero;
            mov.x = Input.GetAxis("Horizontal");
            mov.y = Input.GetAxis("Vertical");

            anim.SetInteger("DirX", System.Convert.ToInt32(mov.x));
            anim.SetInteger("DirY", System.Convert.ToInt32(-mov.y));

            mov.Normalize();

            mov *= Time.deltaTime * Speed;

            rb.MovePosition(rb.position + mov);

        }
    }
}
