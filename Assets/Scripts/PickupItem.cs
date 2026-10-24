using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private string itemID;

    public void Pickup()
    {
        if (InventoryManager.Instance == null)
            return;

        bool added = InventoryManager.Instance.AddItem(itemID);

        if (added)
        {
            gameObject.SetActive(false);
        }
    }
}