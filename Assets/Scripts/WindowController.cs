
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [Header("Blinds")]
    [SerializeField] private GameObject blinds;

    [Header("State")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private StoryCondition lockedCondition;

    public bool IsLocked => isLocked;

    private void Awake()
    {
        UpdateVisual();
    }

    public void ToggleBlinds()
    {
        isLocked = !isLocked;

        UpdateVisual();

        lockedCondition?.SetCondition(isLocked);

        Debug.Log(isLocked ? "Blinds closed" : "Blinds opened");
    }

    private void UpdateVisual()
    {
        if (blinds != null)
            blinds.SetActive(isLocked);
    }
}
