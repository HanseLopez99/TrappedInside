using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public static bool HasKey = false;

    [Header("Player Key")]
    public GameObject playerKey;

    public AudioClip pickupSound;

    // Inventario
    public ItemData itemData;

    private bool pickedUp = false;

    public void PickUp()
    {
        if (pickedUp) return;

        pickedUp = true;

        HasKey = true;

        // Agregar al inventario
        if (itemData != null)
        {
            InventoryManager.Instance.AddItem(
                itemData
            );
        }

        if (playerKey != null)
        {
            playerKey.SetActive(true);
        }

        if (pickupSound)
        {
            AudioSource.PlayClipAtPoint(
                pickupSound,
                transform.position
            );
        }

        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought(
                "Tal vez esto sirva, lo tomaré."
            );
        }

        Destroy(gameObject);
    }
}