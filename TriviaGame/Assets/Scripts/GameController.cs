using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
    public Text questionText;
    public Text resultText;

    public Button[] answerButtons;
    public TriviaQuestion[] questions;
    
    public Sprite pressedstate;
    public Sprite normalSprites;

    private int currentQuestionIndex;
    public float delayBeforeNextQuestion = 2f;



    void Start()
    {
        currentQuestionIndex = 0;
        DisplayQuestion();
       
    }

    public void CheckAnswer(int answerIndex)
    {
        
         answerButtons[answerIndex].GetComponent<Image>().sprite = pressedstate;
       

        if (answerIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            resultText.text = "Correct!";
        }
        else
        {
            resultText.text = "Incorrect. The correct answer is: " + questions[currentQuestionIndex].answers[questions[currentQuestionIndex].correctAnswerIndex];
        }
        // Start a coroutine to delay displaying the next question
        StartCoroutine(NextQuestionWithDelay());
       
    }

    private IEnumerator NextQuestionWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeNextQuestion);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = normalSprites;
        }
        // Move to the next question
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            resultText.text = "Game Over!";
        }
    }
    void DisplayQuestion()
    {
        questionText.text = questions[currentQuestionIndex].question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = questions[currentQuestionIndex].answers[i];
        }

        resultText.text = "";
    }
}
