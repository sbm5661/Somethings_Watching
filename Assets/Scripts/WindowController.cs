using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] private Transform slidingPanel;

    [SerializeField] private float openHeight = 0.7f;

    [SerializeField] private bool isOpen = true;
    [SerializeField] private bool isLocked = false;

    private Vector3 closedPosition;

    public bool IsOpen => isOpen;
    public bool IsLocked => isLocked;

    private void Awake()
    {
        closedPosition = slidingPanel.localPosition;

        UpdateVisual();
    }

    public void ToggleWindow()
    {
        if (isLocked)
        {
            Debug.Log("Window is locked");
            return;
        }

        isOpen = !isOpen;
        UpdateVisual();
    }

    public void ToggleLock()
    {
        if (isOpen)
        {
            Debug.Log("Close the window first");
            return;
        }

        isLocked = !isLocked;
        StoryManager.Instance?.SetStoryFlag("window locked", isLocked);
        Debug.Log(isLocked ? "Window locked" : "Window unlocked");
    }

    private void UpdateVisual()
    {
        slidingPanel.localPosition =
            closedPosition + (isOpen ? Vector3.up * openHeight : Vector3.zero);
    }
}