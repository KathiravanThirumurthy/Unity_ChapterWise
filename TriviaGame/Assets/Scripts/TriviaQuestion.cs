using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriviaQuestion", menuName = "Trivia/Question")]
public class TriviaQuestion : ScriptableObject
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;
}
