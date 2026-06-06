using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public static bool HasFlashlight = false;

    public GameObject playerFlashlight;
    public AudioClip pickupSound;

    // Sonido del seguro de la puerta
    public AudioClip doorUnlockSound;

    // Puerta principal
    public DoorLock mainDoor;

    // Inventario
    public ItemData itemData;

    private bool pickedUp = false;

    public void PickUp()
    {
        if (pickedUp) return;

        pickedUp = true;

        // Marcar que el jugador ya tiene la linterna
        HasFlashlight = true;

        // Agregar al inventario
        if (itemData != null)
        {
            InventoryManager.Instance.AddItem(
                itemData
            );
        }

        // Desbloquear puerta principal
        if (mainDoor != null)
        {
            mainDoor.UnlockDoor();
        }

        // Sonido del seguro de la puerta
        if (doorUnlockSound != null)
        {
            AudioSource.PlayClipAtPoint(
                doorUnlockSound,
                transform.position
            );
        }

        // Activar linterna del jugador
        if (playerFlashlight != null)
        {
            playerFlashlight.SetActive(true);
        }

        // Sonido al recoger
        if (pickupSound)
        {
            AudioSource.PlayClipAtPoint(
                pickupSound,
                transform.position
            );
        }

        // Diálogo
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought(
                "Me pareció escuchar como que se abrió la puerta principal..."
            );
        }

        Destroy(gameObject);
    }
}