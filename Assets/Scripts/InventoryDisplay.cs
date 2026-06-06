using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Transform contentParent;
    public GameObject itemPrefab;

    private void OnEnable()
    {
        InventoryManager.OnItemCollected += AddItemUI;
    }

    private void OnDisable()
    {
        InventoryManager.OnItemCollected -= AddItemUI;
    }

    void AddItemUI(ItemData item)
    {
        GameObject newItem =
            Instantiate(
                itemPrefab,
                contentParent
            );

        InventoryItemUI ui =
            newItem.GetComponent<InventoryItemUI>();

        ui.itemName.text =
            item.itemName;

        ui.icon.sprite =
            item.icon;

        // Forzar actualización inmediata del layout
        LayoutRebuilder.ForceRebuildLayoutImmediate(
            contentParent.GetComponent<RectTransform>()
        );
    }
}