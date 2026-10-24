using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [Header("Lock Settings")]
    [SerializeField] private bool isLocked = false;

    [Header("Visual")]
    [SerializeField] private Transform lockHandle;

    [SerializeField] private float unlockedAngle = 0f;
    [SerializeField] private float lockedAngle = 90f;
    [SerializeField] StoryCondition lockedCondition;

    public bool IsLocked => isLocked;
    private Quaternion initialRotation;

    private void Awake()
    {
        initialRotation = lockHandle.localRotation;
    }

    private void Start()
    {
        UpdateVisual();
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
        UpdateVisual();
        Debug.Log(isLocked ? "Door locked" : "Door unlocked");
    }

    private void UpdateVisual()
    {
        if (lockHandle == null)
            return;

        float angle = isLocked ? lockedAngle : unlockedAngle;

        lockHandle.localRotation =
            initialRotation * Quaternion.Euler(0f, 0f, angle);
    }
}