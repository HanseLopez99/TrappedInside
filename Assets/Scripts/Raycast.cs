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

            // =========================
            // 🔦 LINTERNA
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
            // 🔑 LLAVE
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
            // 📚 ESTANTERÍA SECRETA
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

            interactionText.enabled = false;
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