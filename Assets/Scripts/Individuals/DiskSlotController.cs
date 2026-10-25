
using UnityEngine;
using UnityEngine.Events;

public class DiskSlotController : MonoBehaviour
{
    [SerializeField] private GenericInteractable slotInteraction;

    [Header("State")]
    [SerializeField] private bool isInserted = false;

    [Header("Visuals")]
    [SerializeField] private GameObject insertedDiskVisual;

    [Header("Interaction")]
    [SerializeField] private Collider slotCollider;

    [Header("Events")]
    [SerializeField] private UnityEvent onDiskInserted;
    [SerializeField] private UnityEvent onDiskMissing;

    public bool IsInserted => isInserted;

    private void Start()
    {
        UpdateVisual();
    }

    public void DiskInserted()
    {
        if (isInserted)
            return;

        isInserted = true;

        UpdateVisual();

        Debug.Log("Disk inserted! Processing data...");

        onDiskInserted?.Invoke();
    }

    public void DiskMissing()
    {
        if (isInserted)
            return;

        Debug.Log("Please insert disk.");

        onDiskMissing?.Invoke();
    }

    private void UpdateVisual()
    {
        if (slotInteraction != null)
            slotInteraction.enabled = !isInserted;

        if (insertedDiskVisual != null)
            insertedDiskVisual.SetActive(isInserted);

        if (slotCollider != null)
            slotCollider.enabled = !isInserted;
    }
}
