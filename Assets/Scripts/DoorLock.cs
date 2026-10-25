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
        isLocked = !isLocked;
        if (isLocked)
        {
            lockedCondition?.SetCondition(true);
        }
        else
        {
            lockedCondition?.SetCondition(false);
        }

        Debug.Log(isLocked ? "Door locked" : "Door unlocked");
    }

}