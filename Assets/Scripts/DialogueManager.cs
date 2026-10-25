using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private List<DialogueSequence> dialogueLines = new List<DialogueSequence>();
    int currentdialogue=0;

    public UnityEvent onDialogueStarted;
    public UnityEvent onDialogueFinished;

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

    [ContextMenu("Execute Dialogue")]
    public void ExecuteDialogue()
    {
        StartCoroutine(TriggerDialogue(dialogueLines[currentdialogue].sequence));
        currentdialogue += 1;
    }

    private IEnumerator TriggerDialogue(List<DialogueLine> dialogueLines)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Dialogue triggered");
        dialoguePanel.SetActive(true);

        for (int i = 0; i < dialogueLines.Count; i++)
        {
            dialoguePanel.transform.DOShakePosition(duration: dialogueLines[i].duration, strength: 10f, fadeOut: false);
            dialogueText.text = dialogueLines[i].dialogue;
            yield return new WaitForSeconds(dialogueLines[i].duration);
        }
        dialogueText.text = string.Empty;
        dialoguePanel.SetActive(false);
        onDialogueFinished?.Invoke();
        yield return new WaitForEndOfFrame();
    }
}
