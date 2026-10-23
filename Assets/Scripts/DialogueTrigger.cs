using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    [TextArea(2, 5)]
    public string[] sentences;

    public bool disappearAfterDialogue = false;

    private bool playerIsNear = false;

    void Update()
    {
        if (playerIsNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!dialogueManager.IsDialogueActive())
            {
                dialogueManager.StartDialogue(sentences, this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }

    public void DialogueFinished()
    {
        if (disappearAfterDialogue)
        {
            gameObject.SetActive(false);
        }
    }
}