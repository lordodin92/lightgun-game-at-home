using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTimer;
    public float gameTimer;
    public float overallScore;
    public float hitScore;

    public TMP_Text timerText;
    public TMP_Text overallScoreText;
    public TMP_Text hitScoreText;

    void Start()
    {
        StartCoroutine(StartTimer(gameTimer));
    }

    public IEnumerator StartTimer(float timerValue)
    {
        timerValue = gameTimer;
        currentTimer = timerValue;
        gameTimer = timerValue;

        while (currentTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTimer--;
            timerText.text = currentTimer.ToString("0");
        }
    }

    public void UpdateScore()
    {
        overallScoreText.text = overallScore.ToString("0");
    }

    public void UpdateHits()
    {
        hitScoreText.text = hitScore.ToString("0");
    }
}
