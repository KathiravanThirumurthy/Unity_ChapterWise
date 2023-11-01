using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameControllerJson : MonoBehaviour
{
    public Text questionText;
    public Text resultText;
    public Button[] answerButtons;
    public Sprite pressedstate;
    public Sprite normalSprites;


    private List<QuestionModel> questions;
    private int currentQuestionIndex = 0;
    public float delayBeforeNextQuestion = 2f;

    void Start()
    {
        LoadQuestionsFromJSON();
        DisplayQuestion();
    }

    void LoadQuestionsFromJSON()
    {
        /*
         * Application.streamingAssetsPath: This is a Unity-provided property that represents the path to the "StreamingAssets" folder in
         * your Unity project. The "StreamingAssets" folder is a special folder in Unity where you can place assets that you want to include
         * with your build and access at runtime.
         */
        /*
         * Path.Combine(): This is a .NET method for joining directory and file names into a complete
         */
        string jsonFilePath = Path.Combine(Application.streamingAssetsPath, "questions.json");
        string json = File.ReadAllText(jsonFilePath);
        //deserializing the JSON data into a C# object.
        questions = JsonUtility.FromJson<QuestionsData>(json).questions;
        Debug.Log(questions);
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
        if (currentQuestionIndex < questions.Count)
        {
            DisplayQuestion();
        }
        else
        {
            questionText.text = "";
            resultText.text = "Game Over!";
        }
    }
}
