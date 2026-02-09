using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            if (EscapeManager.Instance != null)
            {
                EscapeManager.Instance.ShowEscapeScreen();
            }
        }
    }
}