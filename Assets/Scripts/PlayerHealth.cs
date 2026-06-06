using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración")]
    public int maxHealth = 100;

    [Header("UI")]
    public Slider healthBar;
    public Image fillImage;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
        }

        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthBar();

        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            PlayerDeath death = GetComponent<PlayerDeath>();

            if (death != null)
            {
                death.Die();
            }
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (fillImage != null)
        {
            float healthPercent =
                (float)currentHealth / maxHealth;

            // Verde
            if (healthPercent > 0.6f)
            {
                fillImage.color =
                    new Color(0f, 0.8f, 0f);
            }
            // Amarillo
            else if (healthPercent > 0.3f)
            {
                fillImage.color =
                    new Color(1f, 0.85f, 0f);
            }
            // Rojo
            else
            {
                fillImage.color =
                    new Color(0.8f, 0f, 0f);
            }
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // NUEVO: usado por el sistema de carga
    public void SetCurrentHealth(int health)
    {
        currentHealth = health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthBar();
    }
}