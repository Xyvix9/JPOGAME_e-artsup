using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    private string[] sentences;
    private int currentSentence;
    private bool dialogueActive = false;

    private DialogueTrigger currentTrigger;

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (dialogueActive && Keyboard.current.eKey.wasPressedThisFrame)
        {
            NextSentence();
        }
    }

    public void StartDialogue(string[] newSentences, DialogueTrigger trigger)
    {
        sentences = newSentences;
        currentSentence = 0;
        currentTrigger = trigger;

        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = sentences[currentSentence];
    }

    void NextSentence()
    {
        currentSentence++;

        if (currentSentence < sentences.Length)
        {
            dialogueText.text = sentences[currentSentence];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);

        if (currentTrigger != null)
        {
            currentTrigger.DialogueFinished();
            currentTrigger = null;
        }
    }

    public bool IsDialogueActive()
    {
        return dialogueActive;
    }
}