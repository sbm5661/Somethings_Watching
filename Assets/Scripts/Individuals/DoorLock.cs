using DG.Tweening;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [Header("Lock Settings")]
    [SerializeField] private bool isLocked = false;

    [Header("Visual")]
    [SerializeField] StoryCondition lockedCondition;

    public bool IsLocked => isLocked;

    public void Interact()
    {
        ToggleLock();
    }

    public void ToggleLock()
    {
        if (isLocked)
        {
            ShakeDoor();
            return;
        }

        if (StoryManager.Instance == null ||
            !StoryManager.Instance.IsCurrentFlag("House Secure"))
        {
            Debug.Log("Shake");
            return;
        }

        isLocked = true;
        lockedCondition?.SetCondition(true);

        Debug.Log("Door locked");
    }

    public void ShakeDoor()
    {
        transform.DOKill();
        transform.DOShakePosition(
            duration: 0.5f,
            strength: new Vector3(0f, 0.05f, 0.05f),
            vibrato: 20,
            randomness: 90f
        );
    }

}