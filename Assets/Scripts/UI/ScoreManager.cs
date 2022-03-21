using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text _highScoreText;
    [SerializeField] TMP_Text _scoreText;
    public static int score;
    int highscore;
    void Start()
    {
        score = 0;
    }

    
    void Update()
    {
        highscore = score;
        _scoreText.text = "SCORE: " + highscore.ToString();
        if (PlayerPrefs.GetInt("score") <= highscore)
        {
            PlayerPrefs.SetInt("score", highscore);
        }
        _highScoreText.text = "HIGHSCORE: \n" + PlayerPrefs.GetInt("score").ToString();
    }
}
