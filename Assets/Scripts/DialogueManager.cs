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

    public Button killButton;
    public Button leaveButton;
    public GameObject lostPanel;

    public Animator anim;

    int DoorToUnlock;
    public bool InDialogue;
    public bool InKillingPhase;
    public bool LastDialogue;
    bool ShouldKill;
    bool ShowKillDialogue;

    public int KilledWrongPerson { get; set; } = 0;
    public int KilledRightPerson { get; set; } = 0;

    private void Awake() {
        if (!Instance) {
            Instance = this;
        }

        killButton.onClick.AddListener(OnKillButtonClick);
        leaveButton.onClick.AddListener(OnLeaveButtonClick);
    }
    private void Start() {
        sentences = new Queue<string>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        if (InDialogue && Input.GetKeyDown(KeyCode.Return)) {
            _audioSource.Stop();
            NextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue, int NextDoor, bool showKillDialogue, bool shouldKill, bool finish = false) {
        ShouldKill = shouldKill;
        ShowKillDialogue = showKillDialogue;
        InDialogue = true;
        LastDialogue = finish;
        DoorToUnlock = NextDoor;
        dialogueBox.SetActive(true);
        sentences.Clear();
        anim.SetBool("IsOpen", true);

        foreach (string sentence in dialogue.sentences) {
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

    public void NextSentence() {
        if (sentences.Count == 0) {
            if (ShowKillDialogue) {
                ShowKillOptions();
            } else {
                EndDialogue();
            }
            return;

        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(WordByWordSentence(sentence));
    }

    IEnumerator WordByWordSentence(string sentence) {
        dialogue.text = "";
        _audioSource.PlayOneShot(DroneSound);

        foreach (char letter in sentence.ToCharArray()) {
            dialogue.text += letter;
            yield return null;
        }

        //Invoke("StopSound" , 1f);

    }

    private void ShowKillOptions() {
        dialogue.text = "";
        InKillingPhase = true;

        killButton.gameObject.SetActive(true);
        leaveButton.gameObject.SetActive(true);
    }

    private void OnKillButtonClick() {
        EndDialogue();

        if (ShouldKill != true) {
            KilledWrongPerson++;
        } else {
            KilledRightPerson++;
        }
    }

    private void OnLeaveButtonClick() {
        EndDialogue();
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        if (LastDialogue) {
            lostPanel.SetActive(true);
            return;
        }

        InDialogue = false;
        InKillingPhase = false;

        anim.SetBool("IsOpen", false);
        //Call next lvl
        if (DoorToUnlock != -1)
        {
            GameManager.instace.OpenDoor(DoorToUnlock);
        }

        killButton.gameObject.SetActive(false);
        leaveButton.gameObject.SetActive(false);

        _audioSource.Stop();

    }

    private void StopSound()
    {
        _audioSource.Stop();
    }
}
