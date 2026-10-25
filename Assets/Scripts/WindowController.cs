using DG.Tweening;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [Header("Blinds")]
    [SerializeField] private Transform blinds;
    [SerializeField] private float openHeight = 1f;
    [SerializeField] private float moveDuration = 0.6f;

    [Header("State")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private StoryCondition lockedCondition;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    public bool IsLocked => isLocked;

    private void Awake()
    {
        // Save world-space positions
        closedPosition = blinds.position;
        openPosition = closedPosition + Vector3.up * openHeight;
    }

    public void ToggleBlinds()
    {
        isLocked = !isLocked;

        // Move smoothly in world space
        blinds.DOMove(
            isLocked ? closedPosition : openPosition,
            moveDuration
        );

        lockedCondition?.SetCondition(isLocked);
    }
}
