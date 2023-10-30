using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Guess : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField guessInput;
    [SerializeField]
    private TMP_Text resultText;
    [SerializeField]
    private Image _uiImage;
    [SerializeField]
    private Sprite defaultImage;
    [SerializeField]
    private Sprite correctImage;
    [SerializeField]
    private Sprite wrongImage;


    private int targetNumber;
    private int attempts = 3;

    void Start()
    {
        // Generate a random target number between 1 and 10
        targetNumber = Random.Range(1, 11);
        Debug.Log(targetNumber);
        guessInput.onEndEdit.AddListener(OnInputFieldEndEdit);
        _uiImage.sprite = defaultImage;
    }

    private void OnInputFieldEndEdit(string value)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // gameManager.uiManager.ResetUI();
            CheckGuess();

        }
    }
    public void CheckGuess()
    {
        int guess;
        if (int.TryParse(guessInput.text, out guess))
        {
            if (guess == targetNumber)
            {
                resultText.text = "Congratulations! You guessed the correct number!";
                _uiImage.sprite = correctImage;
            }
            else
            {
                _uiImage.sprite = wrongImage;
                attempts--;
                if (attempts > 0)
                {
                   // resultText.text = "Wrong guess! Try again. Remaining attempts: " + attempts;
                    if(guess > targetNumber)
                    {
                        resultText.text = "Wrong guess! Try again.The no u guessed is higher, Remaining attempts: " + attempts;
                    }
                    else
                    {
                        resultText.text = "Wrong guess! Try again.The no u guessed is lower, Remaining attempts: " + attempts;
                    }
                }
                else
                {
                    resultText.text = "Out of attempts! The correct number was " + targetNumber;
                }
            }
        }
        else
        {
            resultText.text = "Please enter a valid number.";
        }
    }
}

/*
 int.TryParse(): int.TryParse() is a C# method that attempts to convert a string into an integer.
It is commonly used to validate user input to ensure it can be converted to an integer without causing an error. 
It has the following signature:
int.TryParse(string s, out int result)
string s is the string you want to convert to an integer.
int result is the variable where the parsed integer will be stored if the parsing is successful.
out guess: out is a C# keyword that indicates that the variable guess is an output parameter. 
In this context, it means that if int.TryParse() succeeds in parsing the string from guessInput.text into an integer, 
the resulting integer will be stored in the guess variable.
 */