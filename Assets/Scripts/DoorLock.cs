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
            return;

        if (StoryManager.Instance == null ||
            !StoryManager.Instance.IsCurrentFlag("House Secure"))
            return;

        isLocked = true;
        lockedCondition?.SetCondition(true);

        Debug.Log("Door locked");
    }

}