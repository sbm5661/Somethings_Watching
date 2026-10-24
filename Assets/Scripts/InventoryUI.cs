
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform itemContainer;
    [SerializeField] private InventorySlotUI slotPrefab;

    private void Start()
    {
        inventoryPanel.SetActive(false);

        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged += RefreshIfOpen;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ToggleInventory();
    }

    public void ToggleInventory()
    {
        if (inventoryPanel.activeSelf)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }

    public void OpenInventory()
    {
        RefreshInventory();
        inventoryPanel.SetActive(true);
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    //private void OnEnable()
    //{
    //    if (InventoryManager.Instance != null)
    //        InventoryManager.Instance.OnInventoryChanged += RefreshIfOpen;
    //}

    private void OnDisable()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= RefreshIfOpen;
    }
    private void RefreshInventory()
    {
        // Remove previously created slots
        foreach (Transform child in itemContainer)
            Destroy(child.gameObject);

        if (InventoryManager.Instance == null)
            return;

        // Create a slot for each owned item
        foreach (string itemID in InventoryManager.Instance.GetItems())
        {
            InventorySlotUI slot =
                Instantiate(slotPrefab, itemContainer);

            slot.Setup(itemID, null);
            slot.SetInventoryUI(this);
        }
    }
    private void RefreshIfOpen()
    {
        if (inventoryPanel.activeSelf)
            RefreshInventory();
    }

    public void RefreshSelections()
    {
        foreach (InventorySlotUI slot in
                 itemContainer.GetComponentsInChildren<InventorySlotUI>())
        {
            slot.RefreshSelection();
        }
    }
}
