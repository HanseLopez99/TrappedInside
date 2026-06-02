using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CorpseAI : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public Transform[] patrolPoints;

    [Header("Despertar")]
    public float wakeUpDistance = 5f;
    public float wakeUpDuration = 7f;

    [Header("Detección")]
    public float detectionRange = 10f;
    public float loseRange = 15f;

    [Header("Velocidades")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3f;

    [Header("Ataque")]
    public float attackRange = 2f;
    public int damage = 15;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator animator;

    private bool awakened = false;
    private bool fullyAwake = false;
    private bool isChasing = false;

    private int currentPatrolPoint = 0;
    private float nextAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.enabled = false;

        animator.SetBool("Awake", false);
        animator.SetFloat("Speed", 0);
    }

    void Update()
    {
        if (player == null)
            return;

        // Despertar
        if (!awakened)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    player.position
                );

            if (distance <= wakeUpDistance)
            {
                awakened = true;

                // Mostrar pensamiento del jugador
                if (DialogueManager.Instance != null)
                {
                    DialogueManager.Instance.ShowThought(
                        "¿Qué demonios es esa cosa?"
                    );
                }

                animator.SetBool(
                    "Awake",
                    true
                );

                StartCoroutine(
                    FinishWakeUp()
                );
            }

            return;
        }

        // Esperar que termine de levantarse
        if (!fullyAwake)
            return;

        float distanceToPlayer =
            Vector3.Distance(
                transform.position,
                player.position
            );

        // Detectar jugador
        if (!isChasing &&
            distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            agent.speed = chaseSpeed;
        }

        // Perder jugador
        if (isChasing &&
            distanceToPlayer >= loseRange)
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
                agent.SetDestination(
                    player.position
                );
            }
        }
        else
        {
            Patrol();
        }

        animator.SetFloat(
            "Speed",
            agent.velocity.magnitude
        );
    }

    IEnumerator FinishWakeUp()
    {
        yield return new WaitForSeconds(
            wakeUpDuration
        );

        fullyAwake = true;

        agent.enabled = true;
        agent.speed = patrolSpeed;

        if (patrolPoints.Length > 0)
        {
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
}