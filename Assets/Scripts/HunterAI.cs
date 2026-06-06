using UnityEngine;
using UnityEngine.AI;

public class HunterAI : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public Transform[] patrolPoints;

    [Header("Audio")]
    public AudioSource laughAudio;

    [Header("Detección")]
    public float detectionRange = 10f;
    public float loseRange = 15f;

    [Header("Velocidades")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;

    [Header("Ataque")]
    public float attackRange = 2f;
    public int damage = 20;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator animator;

    private int currentPatrolPoint = 0;
    private bool isChasing = false;

    // Solo mostrar diálogo una vez
    private bool dialogueShown = false;

    private float nextAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = patrolSpeed;

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(
                patrolPoints[currentPatrolPoint].position
            );
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer =
            Vector3.Distance(
                transform.position,
                player.position
            );

        // Detectar jugador
        if (!isChasing && distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            agent.speed = chaseSpeed;

            // Reproducir risa cuando inicia la persecución
            if (laughAudio != null)
            {
                laughAudio.Play();
            }

            // Mostrar diálogo solo la primera vez
            if (!dialogueShown &&
                DialogueManager.Instance != null)
            {
                dialogueShown = true;

                DialogueManager.Instance.ShowThought(
                    "¿Qué le pasa a este loco?"
                );
            }
        }

        // Perder jugador
        if (isChasing && distanceToPlayer >= loseRange)
        {
            isChasing = false;
            agent.speed = patrolSpeed;

            if (patrolPoints.Length > 0)
            {
                agent.SetDestination(
                    patrolPoints[currentPatrolPoint].position
                );
            }
        }

        // Perseguir o atacar
        if (isChasing)
        {
            if (distanceToPlayer <= attackRange)
            {
                Attack();
            }
            else
            {
                agent.SetDestination(player.position);
            }
        }
        else
        {
            Patrol();
        }

        // Actualizar animaciones
        animator.SetFloat(
            "Speed",
            agent.velocity.magnitude
        );
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        if (!agent.pathPending &&
            agent.remainingDistance < 1f)
        {
            currentPatrolPoint++;

            if (currentPatrolPoint >= patrolPoints.Length)
            {
                currentPatrolPoint = 0;
            }

            agent.SetDestination(
                patrolPoints[currentPatrolPoint].position
            );
        }
    }

    void Attack()
    {
        agent.ResetPath();

        Vector3 lookPosition =
            new Vector3(
                player.position.x,
                transform.position.y,
                player.position.z
            );

        transform.LookAt(lookPosition);

        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");

            PlayerHealth playerHealth =
                player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            nextAttackTime =
                Time.time + attackCooldown;
        }
    }
}