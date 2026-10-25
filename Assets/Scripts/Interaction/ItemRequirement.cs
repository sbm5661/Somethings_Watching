using UnityEngine;
using UnityEngine.Events;

public class ItemRequirement : MonoBehaviour
{
    [Header("Required Item")]
    [SerializeField] private string requiredItemID;
    [SerializeField] private bool requireSelection = true;

    [SerializeField] private bool consumeOnUse = false;
    [SerializeField] private bool useOnce = false;
    private bool hasBeenUsed = false;

    [Header("Events")]
    [SerializeField] private UnityEvent onSuccess;
    [SerializeField] private UnityEvent onFailure;

    public void TryUse()
    {
        if (InventoryManager.Instance == null)
            return;

        if (useOnce && hasBeenUsed)
            return;

        InventoryManager inventory = InventoryManager.Instance;

        if (!inventory.HasItem(requiredItemID))
        {
            onFailure?.Invoke();
            return;
        }

        if (requireSelection && inventory.SelectedItemID != requiredItemID)
        {
            onFailure?.Invoke();
            return;
        }

        if (consumeOnUse)
            inventory.RemoveItem(requiredItemID);

        if (useOnce)
            hasBeenUsed = true; 

        onSuccess?.Invoke();
    }
}