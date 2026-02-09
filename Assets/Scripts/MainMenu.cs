using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject optionsMenuPanel;

    [Header("Scenes")]
    public string gameSceneName = "Game";

    void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Estado inicial
        mainMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
    }

    // PLAY
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(gameSceneName);
    }

    // OPTIONS
    public void OpenOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    // BACK
    public void CloseOptions()
    {
        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // QUIT
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}