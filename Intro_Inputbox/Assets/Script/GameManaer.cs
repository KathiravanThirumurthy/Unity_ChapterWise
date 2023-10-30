using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManaer : MonoBehaviour
{
    public GameLogic gameLogic;
    public UIMnager uiManager;
    private bool isGameOver = true;

    // Start is called before the first frame update
    void Start()
    {
        StartNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNewGame()
    {
        int randomValue = NumberGenerator.GenerateRandomNumber(1, 10);
        Debug.Log("Generated Random Number: " + randomValue);
        gameLogic.InitializeGame(randomValue);
        uiManager.ResetUI();
       
    }

    public void MakeGuess(int guess)
    {
        gameLogic.ProcessGuess(guess);
    }

    public void GameOver(bool val)
    {
        isGameOver = true;
        uiManager.GameOver(val);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
