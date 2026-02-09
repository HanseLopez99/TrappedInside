using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeManager : MonoBehaviour
{
    public static EscapeManager Instance;

    public GameObject escapeScreen;
    private bool escaped = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        escapeScreen.SetActive(false);
    }

    void Update()
    {
        if (!escaped) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    public void ShowEscapeScreen()
    {
        escaped = true;
        Time.timeScale = 0f;
        escapeScreen.SetActive(true);
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}