using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public static bool HasFlashlight = false;   // 👈 ESTA ES LA CLAVE

    public GameObject playerFlashlight;
    public AudioClip pickupSound;

    private bool pickedUp = false;

    public void PickUp()
    {
        if (pickedUp) return;
        pickedUp = true;

        // 🔑 Marcar que el jugador ya tiene la linterna
        HasFlashlight = true;

        if (playerFlashlight != null)
            playerFlashlight.SetActive(true);

        if (pickupSound)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        if (DialogueManager.Instance != null)
            DialogueManager.Instance.ShowThought("Esto puede servirme...");

        Destroy(gameObject);
    }
}