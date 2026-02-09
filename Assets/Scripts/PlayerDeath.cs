using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private bool isDead = false;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Car"))
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Desactivar movimiento del jugador
        if (controller != null)
        {
            controller.enabled = false;
        }

        // Mostrar pantalla de muerte
        if (DeathManager.Instance != null)
        {
            DeathManager.Instance.ShowDeathScreen();
        }
    }
}