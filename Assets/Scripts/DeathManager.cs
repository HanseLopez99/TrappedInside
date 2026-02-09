using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Instance;

    public GameObject deathScreen;

    private bool isDead = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        deathScreen.SetActive(false);
    }

    void Update()
    {
        if (!isDead) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            RestartLevel();
        }
    }

    public void ShowDeathScreen()
    {
        isDead = true;
        Time.timeScale = 0f; // Pausar el juego
        deathScreen.SetActive(true);
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}