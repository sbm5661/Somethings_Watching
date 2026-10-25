using System.Collections;
using UnityEngine;

public class DelayedDialogue : MonoBehaviour
{
    [SerializeField] private float delay = 2f;

    public void Play()
    {
        StartCoroutine(PlayAfterDelay());
    }

    private IEnumerator PlayAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        DialogueManager.Instance.ExecuteDialogue();
    }
}