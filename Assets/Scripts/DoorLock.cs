using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public HingeJoint hinge;
    public Rigidbody rb;

    private bool locked = false;

    void Start()
    {
        LockDoorWithoutDialogue();
    }

    public void LockDoor()
    {
        if (locked) return;

        locked = true;

        if (rb != null)
            rb.angularVelocity = Vector3.zero;

        JointLimits limits = hinge.limits;
        limits.min = 0f;
        limits.max = 0f;
        hinge.limits = limits;
        hinge.useLimits = true;

        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought(
                "Noo, la puerta se cerró... Debo escapar de aquí rápido."
            );
        }
    }

    public void LockDoorWithoutDialogue()
    {
        locked = true;

        if (rb != null)
            rb.angularVelocity = Vector3.zero;

        JointLimits limits = hinge.limits;
        limits.min = 0f;
        limits.max = 0f;
        hinge.limits = limits;
        hinge.useLimits = true;
    }

    public void UnlockDoor()
    {
        locked = false;
        hinge.useLimits = false;
    }

    public bool IsLocked()
    {
        return locked;
    }
}