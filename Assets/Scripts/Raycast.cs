using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private Image uiCrosshair;

    [Header("UI")]
    [SerializeField] private Text objectText;
    [SerializeField] private TextMeshProUGUI interactionText;

    [Header("Door Event")]
    [SerializeField] private DoorLock mainDoor;

    private bool doorEventTriggered = false;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.forward;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract))
        {
            crosshairActive();

            // TEXTO DEL OBJETO
            objectText.enabled = true;
            objectText.text = hit.collider.tag;

            Transform root = hit.collider.transform.root;

            // =========================
            // 🔦 LINTERN A (PICKUP)
            // =========================
            FlashlightPickup flashlight =
                hit.collider.GetComponentInParent<FlashlightPickup>();

            if (flashlight != null)
            {
                interactionText.enabled = true;
                interactionText.text = "[E] / Click para recoger";

                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
                {
                    flashlight.PickUp();
                }

                return;
            }

            // =========================
            // LLAVE (PICKUP)
            // =========================
            KeyPickup key =
                hit.collider.GetComponentInParent<KeyPickup>();

            if (key != null)
            {
                interactionText.enabled = true;
                interactionText.text = "[E] / Click para recoger";

                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
                {
                    key.PickUp();
                }

                return;
            }

            // =========================
            // BOOKSHELF SECRETO
            // =========================
            SecretBookshelf shelf =
                hit.collider.GetComponentInParent<SecretBookshelf>();

            if (shelf != null)
            {
                interactionText.enabled = true;
                interactionText.text = "[E] Empujar";

                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
                {
                    shelf.TryActivate();
                }

                return;
            }

            // =========================
            // EVENTO: CERRAR PUERTA PRINCIPAL
            // =========================
            interactionText.enabled = false;

            bool isExcluded =
                root.CompareTag("Flashlight") ||
                root.CompareTag("Door") ||
                root.CompareTag("Car") ||
                root.CompareTag("Key");

            if (!doorEventTriggered &&
                FlashlightPickup.HasFlashlight &&
                !isExcluded)
            {
                doorEventTriggered = true;

                if (mainDoor != null)
                {
                    mainDoor.LockDoor();
                }
            }
        }
        else
        {
            objectText.enabled = false;
            interactionText.enabled = false;
            crosshairNormal();
        }
    }

    void crosshairActive()
    {
        uiCrosshair.color = Color.red;
    }

    void crosshairNormal()
    {
        uiCrosshair.color = Color.white;
    }
}