using UnityEngine;

public class SecretBookshelf : MonoBehaviour
{
    [Header("Movement")]
    public Transform targetPosition;   // destino
    public float speed = 1.5f;
    public float stopDistance = 0.02f; // tolerancia de llegada

    private bool activated = false;
    private bool finished = false;

    void Update()
    {
        if (!activated || finished) return;
        if (targetPosition == null) return;

        // Mover hasta el destino (llega EXACTO)
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition.position,
            speed * Time.deltaTime
        );

        // ¿Ya llegó?
        if (Vector3.Distance(transform.position, targetPosition.position) <= stopDistance)
        {
            FinishMovement();
        }
    }

    public void TryActivate()
    {
        if (activated) return;

        if (KeyPickup.HasKey)
        {
            activated = true;

            if (DialogueManager.Instance != null)
            {
                DialogueManager.Instance.ShowThought("Se movió...");
            }
        }
        else
        {
            if (DialogueManager.Instance != null)
            {
                DialogueManager.Instance.ShowThought(
                    "No parece moverse..."
                );
            }
        }
    }

    void FinishMovement()
    {
        finished = true;

        // Asegurar posición final exacta
        transform.position = targetPosition.position;

        // Volverlo estático (runtime)
        gameObject.isStatic = true;

        // Ya no necesita Update
        enabled = false;
    }
}