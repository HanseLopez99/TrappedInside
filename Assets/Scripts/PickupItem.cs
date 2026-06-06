using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemData itemData;

    public virtual void PickUp()
    {
        if (itemData != null)
        {
            InventoryManager.Instance.AddItem(
                itemData
            );
        }

        Destroy(gameObject);
    }
}