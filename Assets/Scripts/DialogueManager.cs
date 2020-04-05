using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    Queue<string> sentences;

    public Text dialogue;
    public GameObject dialogueBox;
    private AudioSource _audioSource;
    public AudioClip DroneSound;


    public Animator anim;

    int DoorToUnlock;
    public bool InDialogue;
    bool ShouldKill;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        sentences = new Queue<string>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (InDialogue && Input.GetKeyDown(KeyCode.Return))
        {
            _audioSource.Stop();
            NextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue, int NextDoor, bool shouldKill)
    {
        ShouldKill = shouldKill;
        InDialogue = true;
        DoorToUnlock = NextDoor;
        dialogueBox.SetActive(true);
        sentences.Clear();
        anim.SetBool("IsOpen", true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();

        // seems like there is a bug here where even if i commented this line i can still skip the dialogue with "Enter" button 
        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            NextSentence();
            Debug.Log("ss");
        }*/

    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;

        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(WordByWordSentence(sentence));
    }

    IEnumerator WordByWordSentence(string sentence)
    {
        dialogue.text = "";
        _audioSource.PlayOneShot(DroneSound);

        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return null;
        }

        //Invoke("StopSound" , 1f);

    }

    private void EndDialogue()
    {
        InDialogue = false;

        dialogueBox.SetActive(false);
        anim.SetBool("IsOpen", false);
        //Call next lvl
        if (DoorToUnlock != -1)
        {
            GameManager.instace.OpenDoor(DoorToUnlock);
        }

        _audioSource.Stop();

    }

    private void StopSound()
    {
        _audioSource.Stop();
    }
}
