using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    [SerializeField] UpdateText nameText;
    [SerializeField] UpdateText dialogueText;
    [SerializeField] Animator animator;

    CharacterMovement characterMovement;
    Timer timer;

    void Start()
    {
        sentences = new Queue<string>();
        characterMovement = FindObjectOfType<CharacterMovement>();
        timer = FindObjectOfType<Timer>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.UpdateTextAs(dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        characterMovement.PauseCharacterControl();
        timer.PauseTimer();

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.UpdateTextAs("");
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.UpdateTextAs(dialogueText.GetCurrentText() + letter);
            yield return null;
        }

    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        characterMovement.ResumeCharacterControl();
        timer.ResumeTimer();
    }
}
