
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image slotBackground;

    [SerializeField] private Color normalColor = Color.gray;
    [SerializeField] private Color selectedColor = Color.white;

    private string itemID;
    [SerializeField] private InventoryUI inventoryUI;

    public void Setup(string id, Sprite icon)
    {
        itemID = id;

        itemIcon.sprite = icon;
        itemIcon.enabled = icon != null;

        RefreshSelection();
    }

    public void OnClick()
    {
        InventoryManager inventory = InventoryManager.Instance;

        if (inventory == null)
            return;

        if (inventory.SelectedItemID == itemID)
            inventory.ClearSelection();
        else
            inventory.SelectItem(itemID);

        if (inventoryUI != null)
            inventoryUI.RefreshSelections();
        else
            RefreshSelection();
    }

    public void RefreshSelection()
    {
        if (InventoryManager.Instance == null)
            return;

        bool selected =
            InventoryManager.Instance.SelectedItemID == itemID;

        slotBackground.color =
            selected ? selectedColor : normalColor;
    }
    public void SetInventoryUI(InventoryUI ui)
    {
        inventoryUI = ui;
    }
}
