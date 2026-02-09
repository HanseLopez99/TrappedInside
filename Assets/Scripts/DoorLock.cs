using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public HingeJoint hinge;
    public Rigidbody rb;

    private bool locked = false;

    public void LockDoor()
    {
        if (locked) return;
        locked = true;

        // Detener cualquier movimiento
        if (rb != null)
            rb.angularVelocity = Vector3.zero;

        // Bloquear la puerta
        JointLimits limits = hinge.limits;
        limits.min = 0f;
        limits.max = 0f;
        hinge.limits = limits;
        hinge.useLimits = true;

        // Diálogo
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought("Noo, la puerta se cerró... Debo escapar de aquí rápido.");
        }
    }
}