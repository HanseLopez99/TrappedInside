using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public static bool HasKey = false;

    [Header("Player Key")]
    public GameObject playerKey;   // 👈 referencia al Key del player

    public AudioClip pickupSound;

    private bool pickedUp = false;

    public void PickUp()
    {
        if (pickedUp) return;
        pickedUp = true;

        HasKey = true;

        if (playerKey != null)
            playerKey.SetActive(true);   // 👈 AQUÍ SE ACTIVA

        if (pickupSound)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought(
                "Tal vez esto sirva, lo tomaré."
            );
        }

        Destroy(gameObject);
    }
}