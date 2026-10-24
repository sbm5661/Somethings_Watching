using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private List<string> dialogueQueue = new List<string>();
    [SerializeField] private TextMeshProUGUI dialogueText;

    private void Start()
    {
        if (dialogueQueue.Count > 0)
        {
            Debug.Log($"Starting dialogue");
            TriggerDialogue();
        }
        else
        {
            Debug.Log("No dialogue to start.");
        }
    }

    public void EnqueueDialogue(string dialogue)
    {
        dialogueQueue.Add(dialogue);
        Debug.Log($"Dialogue added: {dialogue}");
        TriggerDialogue();
    }
    public void EnqueueDialogue(string[] dialogues)
    {
        foreach (string dialogue in dialogues)
        {
            dialogueQueue.Add(dialogue);
            Debug.Log($"Dialogue added: {dialogue}");
        }
        TriggerDialogue();
    }

    public void DequeueDialogue()
    {
        if (dialogueQueue.Count > 0)
        {
            string dialogue = dialogueQueue[0];
            dialogueQueue.RemoveAt(0);
            Debug.Log($"Dialogue removed: {dialogue}");
            TriggerDialogue();
        }
        else
        {
            Debug.Log("No dialogue to remove.");
        }
    }

    private void TriggerDialogue()
    {
        if (dialogueQueue.Count > 0)
        {
            dialogueText.text = dialogueQueue[0];
            dialogueText.DOFade(1f, 0.5f).OnComplete(() =>
            {
                dialogueText.DOFade(0f, 1.5f).SetDelay(2f).OnComplete(() =>
                {
                    DequeueDialogue();
                });
            });
        }
        else
        {
            return;
        }
    }
}
