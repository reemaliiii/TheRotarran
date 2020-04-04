using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    DialogueTrigger DT;
    public float movementSpeed = 10;
    Vector2 dir;
    private GameObject Character;
    public GameObject InteractionText;
    public AudioManager audioManager;

    // counter to stop the bug where you can reset the dialogue even before finishing it.
    private int cnt = 1;


    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        transform.Translate(dir * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Char")
        {
            InteractionText.SetActive(true);
            audioManager.Play("pressT");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Char" && Input.GetKeyDown(KeyCode.T) && cnt == 1)
        {
            Character = collision.gameObject;
            Debug.Log("convo started");
            Character.GetComponent<DialogueTrigger>().TriggerDialogue();
            audioManager.Play("narratorBackground");
            cnt = 0;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Char")
        {
            InteractionText.SetActive(false);
            cnt = 1;
        }
    }

}
