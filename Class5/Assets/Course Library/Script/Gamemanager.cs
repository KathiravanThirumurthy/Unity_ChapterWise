using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    private bool isGameOver = true;
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private PauseManager pauseManager; // Assign the PauseManager in the Inspector.

    private void Start()
    {
        // Ensure the PauseManager is properly set in the Inspector.
        if (pauseManager == null)
        {
            Debug.LogError("PauseManager not set in the Inspector.");
        }
    }
    public void GameOver(bool val)
    {
        isGameOver = true;
        _uiManager.GameOver(val);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGamePause()
    {
        // Handle game pause, e.g., show a pause menu.
    }

    public void OnGameResume()
    {
        // Handle game resume, e.g., hide the pause menu.
    }

    public void OnGameOver(bool isGameOver)
    {
        if (isGameOver)
        {
            // Handle game over logic.
        }
    }
    // Trigger pause and resume based on game events.
    private void pauseGameEvent()
    {
        pauseManager.TogglePause(); // Trigger the pause.
    }

    private void resumeEvent()
    {
        pauseManager.TogglePause(); // Trigger the resume after the specified duration.
    }


    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
