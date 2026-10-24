using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private HashSet<string> items = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public bool AddItem(string itemID)
    {
        if (string.IsNullOrEmpty(itemID))
            return false;

        bool added = items.Add(itemID);

        if (added)
            Debug.Log("Obtained: " + itemID);

        return added;
    }

    public bool HasItem(string itemID)
    {
        return items.Contains(itemID);
    }

    public bool RemoveItem(string itemID)
    {
        return items.Remove(itemID);
    }
}