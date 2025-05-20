using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValueText;
    [SerializeField] TextMeshProUGUI highScoreValueText;
    public float scorePerSecond = 1f;
    public float scoreValue;
    public float highScoreValue;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreValue = PlayerPrefs.GetFloat("HighScore");
        }
    }

    private void FixedUpdate()
    {
        ScoreByTime();
    }

    private void ScoreByTime()
    {
        scoreValue += scorePerSecond * Time.fixedDeltaTime;

        scoreValueText.text = ((int)scoreValue).ToString();
        highScoreValueText.text = ((int)highScoreValue).ToString();
    }

    public void GiveScore(float score)
    {
        scoreValue += score;

        if (scoreValue > highScoreValue)
        {
            highScoreValue = scoreValue;
            PlayerPrefs.SetFloat("HighScore", highScoreValue);
        }
    }
}
