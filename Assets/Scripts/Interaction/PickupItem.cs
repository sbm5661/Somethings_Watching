using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
public class PickupItem : MonoBehaviour
{
    [SerializeField] private string itemID;
    [SerializeField] private UnityEvent onPickedUp;
    [SerializeField] private string pickupStoryFlag = string.Empty;
    public void Pickup()
    {
        if (InventoryManager.Instance == null)
            return;

        if (pickupStoryFlag != string.Empty && !StoryManager.Instance.IsCurrentFlag("Leaving"))
        {
            transform.DOShakePosition(duration: 0.5f, strength: new Vector3(0.05f, 0f, 0.05f), vibrato: 20, randomness: 90f);
            return;
        }

        bool added = InventoryManager.Instance.AddItem(itemID);

        if (added)
        {
            onPickedUp?.Invoke();
            gameObject.SetActive(false);
        }
    }
}