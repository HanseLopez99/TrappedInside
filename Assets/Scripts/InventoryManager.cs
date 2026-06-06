using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Evento para actualizar la UI
    public static Action<ItemData> OnItemCollected;

    public List<ItemData> collectedItems =
        new List<ItemData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemData item)
    {
        if (item == null)
            return;

        collectedItems.Add(item);

        // Notificar a la UI
        OnItemCollected?.Invoke(item);

        Debug.Log(
            "Recogido: " +
            item.itemName
        );
    }
}