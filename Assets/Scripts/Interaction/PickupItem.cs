using UnityEngine;
using UnityEngine.Events;
public class PickupItem : MonoBehaviour
{
    [SerializeField] private string itemID;
    [SerializeField] private UnityEvent onPickedUp;
    public void Pickup()
    {
        if (InventoryManager.Instance == null)
            return;

        bool added = InventoryManager.Instance.AddItem(itemID);

        if (added)
        {
            onPickedUp?.Invoke();
            gameObject.SetActive(false);
        }
    }
}