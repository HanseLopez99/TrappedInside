using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private float displayTime = 4f;

    private Coroutine currentRoutine;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        dialogueText.enabled = false;
    }

    public void ShowThought(string message)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(ShowRoutine(message));
    }

    private IEnumerator ShowRoutine(string message)
    {
        dialogueText.text = message;
        dialogueText.enabled = true;

        yield return new WaitForSeconds(displayTime);

        dialogueText.enabled = false;
    }
}