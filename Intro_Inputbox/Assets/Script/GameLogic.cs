using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameManaer gameManager;
   // private UpdateImage updateImage;
    private int targetNumber;
    private int attempts;
    [SerializeField]
    private Sprite guessImage;
    [SerializeField]
    private Sprite trueImage;
    [SerializeField]
    private Sprite falseImage;
    private PauseManager _pauseManager;

    private void Awake()
    {
        _pauseManager = FindObjectOfType<PauseManager>();
       
    }
    public void InitializeGame(int target)
    {
        targetNumber = target;
        attempts = 5;
        gameManager.uiManager.UpdateUIImage(guessImage);
        gameManager.uiManager.intializeLife(attempts);
    }

    public void ProcessGuess(int guess)
    {
        int attemptMade = targetNumber - attempts;
        if (attempts > 0)
        {
            if (guess == targetNumber)
            {
                gameManager.StartNewGame();
                gameManager.uiManager._instructionText.text = "Congratulations! You guessed the number.";
                //gameManager.uiManager.UpdateUIImage(trueImage);
                //gameManager.GameOver(false);
                _pauseManager.TogglePause();
            }
            else
            {
                attempts--;
                gameManager.uiManager._attemptsText.text = "Attempts left: " + attempts + "and attempts made :" + attemptMade;
                gameManager.uiManager._instructionText.text = "Try again. " + (guess < targetNumber ? "Higher" : "Lower");
                gameManager.uiManager.UpdateUIImage(falseImage);
                gameManager.uiManager.UpdateLifeImage(attempts);
            }
        }
        else
        {
            gameManager.uiManager._instructionText.text = "You've run out of attempts. The number was " + targetNumber;
        }
    }
}
