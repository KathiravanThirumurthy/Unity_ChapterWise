using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private float pauseDuration = 2.0f;
    private bool isPaused = false;
    private GameManaer _gamemanager;
    private bool isResuming = false;

    void Start()
    {
        _gamemanager = FindObjectOfType<GameManaer>();
    }
    private void Update()
    {

    }

    public void TogglePause()
    {

        if (isPaused)
        {

            isPaused = false;
            Time.timeScale = 1f;
            _gamemanager.GameOver(false);
            _gamemanager.RestartGame();

        }
        else
        {
            _gamemanager.GameOver(true);
            Time.timeScale = 0f;
            isPaused = true;
            StartCoroutine(ResumeAfterDelay());

        }

    }

    private IEnumerator ResumeAfterDelay()
    {
        // Pause duration of 3 seconds.
        yield return new WaitForSecondsRealtime(pauseDuration); 
        Time.timeScale = 1f; // Resume the game.
        TogglePause();
        // GameManager.Instance.OnGameResume();

    }

}
