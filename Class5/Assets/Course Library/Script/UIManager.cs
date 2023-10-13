using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _gameOver;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore(int point)
    {
        score += point;
        UpdateScoreText(score);
    }
    private void UpdateScoreText(int score)
    {
        _scoreText.text = "Score : " + score.ToString();
    }
    public void GameOver(bool val)
    {
        _gameOver.gameObject.SetActive(val);
    }
}
