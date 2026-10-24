using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public Action onDialogueFinished;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        dialogueText.text = string.Empty;
        dialoguePanel.SetActive(false);
    }

    public IEnumerator TriggerDialogue(Tuple<string, float>[] dialogueLines)
    {
        dialoguePanel.SetActive(true);

        for (int i = 0; i < dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueLines[i].Item1;
            yield return new WaitForSeconds(dialogueLines[i].Item2);
        }
        dialogueText.text = string.Empty;
        dialoguePanel.SetActive(false);
        onDialogueFinished?.Invoke();
        yield return new WaitForEndOfFrame();
    }
}
