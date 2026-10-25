using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private HashSet<string> items = new();
    public string SelectedItemID { get; private set; }
    public event Action OnInventoryChanged;

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
        {
            Debug.Log("Obtained: " + itemID);
            OnInventoryChanged?.Invoke();
        }

        return added;
    }

    public bool HasItem(string itemID)
    {
        return items.Contains(itemID);
    }

    public bool RemoveItem(string itemID)
    {
        bool removed = items.Remove(itemID);

        if (removed)
        {
            if (SelectedItemID == itemID)
                ClearSelection();

            OnInventoryChanged?.Invoke();
        }

        return removed;
    }

    public void SelectItem(string itemID)
    {
        if (HasItem(itemID))
            SelectedItemID = itemID;
    }
    public IEnumerable<string> GetItems()
    {
        return items;
    }
    public void ClearSelection()
    {
        SelectedItemID = null;
    }

}