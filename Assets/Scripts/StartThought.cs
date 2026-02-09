using UnityEngine;

public class StartThought : MonoBehaviour
{
    void Start()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought("¿Dónde estoy...?");
        }
    }
}