
using DG.Tweening;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [Header("Blinds")]
    [SerializeField] private Transform blinds;
    [SerializeField] private float openHeight = -1f;
    [SerializeField] private float moveDuration = 0.6f;

    [Header("State")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private StoryCondition lockedCondition;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    public bool IsLocked => isLocked;

    private void Awake()
    {
        // Blinds start in the open (raised) position
        openPosition = blinds.position;
        closedPosition = openPosition + Vector3.up * openHeight;
    }

    public void ToggleBlinds()
    {
        if (StoryManager.Instance == null ||
            !StoryManager.Instance.IsCurrentFlag("House Secure"))
            return;

        // Already closed; prevent reopening for now
        if (isLocked)
            return;

        isLocked = true;

        // Stop any previous movement before starting a new one
        blinds.DOKill();

        blinds.DOMove(closedPosition, moveDuration);

        lockedCondition?.SetCondition(true);
    }
}
