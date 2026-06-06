using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class HouseEntryEvent : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject scaredGuy;
    public Transform doorTarget;
    public DoorLock mainDoor;

    [Header("Audio")]
    public AudioSource screamAudio;

    [Header("Cámaras")]
    public GameObject fpsCamera;
    public GameObject cinematicCamera;

    [Header("Jugador")]
    public GameObject playerFlashlight;

    [Header("Configuración")]
    public float standUpDuration = 2.5f;

    private bool triggered = false;
    private bool doorClosed = false;
    private bool startedRunning = false;

    private bool flashlightWasOn = false;

    private NavMeshAgent agent;
    private Animator animator;

    private FirstPersonController playerController;

    void Start()
    {
        playerController =
            FindObjectOfType<FirstPersonController>();

        if (scaredGuy != null)
        {
            agent = scaredGuy.GetComponent<NavMeshAgent>();
            animator = scaredGuy.GetComponent<Animator>();

            if (agent != null)
            {
                agent.stoppingDistance = 1.5f;
            }
        }

        if (cinematicCamera != null)
        {
            cinematicCamera.SetActive(false);
        }
    }

    void Update()
    {
        if (!triggered ||
            doorClosed ||
            !startedRunning ||
            agent == null)
            return;

        if (!agent.pathPending &&
            agent.remainingDistance <= 1.5f)
        {
            CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
            return;

        if (!other.CompareTag("Player"))
            return;

        triggered = true;

        // Bloquear movimiento
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // Cambiar cámara
        if (fpsCamera != null)
        {
            fpsCamera.SetActive(false);
        }

        if (cinematicCamera != null)
        {
            cinematicCamera.SetActive(true);
        }

        // Guardar estado de linterna
        if (playerFlashlight != null)
        {
            flashlightWasOn =
                playerFlashlight.activeSelf;

            playerFlashlight.SetActive(false);
        }

        // Grito de miedo
        if (screamAudio != null)
        {
            screamAudio.Play();
        }

        // Pray -> StandUp
        if (animator != null)
        {
            animator.SetTrigger("RunAway");
        }

        Invoke(
            nameof(StartRunning),
            standUpDuration
        );
    }

    void StartRunning()
    {
        if (agent == null)
            return;

        startedRunning = true;

        agent.isStopped = false;

        agent.SetDestination(
            doorTarget.position
        );
    }

    void CloseDoor()
    {
        if (doorClosed)
            return;

        doorClosed = true;

        // Detener Remy
        if (agent != null)
        {
            agent.isStopped = true;
            agent.ResetPath();
        }

        if (mainDoor != null)
        {
            mainDoor.LockDoor();
        }

        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought(
                "¿Me encerró aquí adentro?"
            );
        }

        // Desaparecer Remy
        if (scaredGuy != null)
        {
            scaredGuy.SetActive(false);
        }

        // Restaurar cámara
        if (fpsCamera != null)
        {
            fpsCamera.SetActive(true);
        }

        if (cinematicCamera != null)
        {
            cinematicCamera.SetActive(false);
        }

        // Restaurar movimiento
        if (playerController != null)
        {
            playerController.enabled = true;
        }

        // Restaurar linterna
        if (playerFlashlight != null &&
            flashlightWasOn)
        {
            playerFlashlight.SetActive(true);
        }
    }
}