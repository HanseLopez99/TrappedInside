using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("UI")]
    public GameObject pauseMenuUI;

    [Header("Scenes")]
    public string mainMenuSceneName = "MenuScene";

    void Start()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    //   CONTINUE
    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameIsPaused = false;
    }

    //   PAUSE
    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameIsPaused = true;
    }

    // RESTART LEVEL
    public void RestartGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameIsPaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // BACK TO MAIN MENU
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameIsPaused = false;

        SceneManager.LoadScene(mainMenuSceneName);
    }

    // QUIT GAME
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}