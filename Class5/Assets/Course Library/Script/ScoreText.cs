using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _gameOver;
    private int score=0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        _scoreText.text = "Score : " + score.ToString();
    }

   
}
