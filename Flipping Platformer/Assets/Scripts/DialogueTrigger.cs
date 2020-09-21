using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] Dialogue[] dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[0]);
    }
    public void TriggerDialogue(int index)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[index]);
    }
    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
