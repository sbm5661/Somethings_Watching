
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
    [SerializeField] private StoryCondition glintCondition;

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
        // Already closed; prevent reopening for now
        if (isLocked)
        {
            transform.DOShakePosition(duration: 0.5f, strength: new Vector3(0f, 0.05f, 0.05f), vibrato: 20, randomness: 90f);
            return;
        }

        if (StoryManager.Instance == null) return;
        if (StoryManager.Instance.IsCurrentFlag("Window Glint"))
        {
            blinds.DOKill();
            blinds.DOMove(openPosition, moveDuration);
            glintCondition.SetCondition(true);
            return;
        }
        if (!StoryManager.Instance.IsCurrentFlag("House Secure"))return;

        isLocked = true;

        // Stop any previous movement before starting a new one
        blinds.DOKill();

        blinds.DOMove(closedPosition, moveDuration);

        lockedCondition?.SetCondition(true);
    }

    public void Unlock()
    {
        isLocked = false;
    }
}
