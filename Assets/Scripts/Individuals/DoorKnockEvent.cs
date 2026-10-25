using System.Collections;
using UnityEngine;

public class DoorKnockEvent : MonoBehaviour
{
    [SerializeField] private AudioSource knockAudio;
    [SerializeField] private float initialDelay = 0f;
    [SerializeField] private float dialogueDelay = 2f;

    public void TriggerKnock()
    {
        StartCoroutine(KnockSequence());
    }

    private IEnumerator KnockSequence()
    {
        yield return new WaitForSeconds(initialDelay);

        knockAudio.Play();

        // Wait until the knocking sound finishes
        yield return new WaitWhile(() => knockAudio.isPlaying);

        // Brief silence before the dialogue
        yield return new WaitForSeconds(dialogueDelay);

        DialogueManager.Instance.ExecuteDialogue();
    }
}