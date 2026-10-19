using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTimer;
    public float gameTimer;
    public float maxGameScore;
    public float overallScore;
    public float hitScore;

    public TMP_Text timerText;
    public TMP_Text overallScoreText;
    public TMP_Text hitScoreText;

    public float timeDelay;
    public float normalSpeed;
    public float slowSpeed;

    SlowTime slowTime;
    public GameObject slowTimeButton;

    void Start()
    {
        slowTime = slowTimeButton.GetComponent<SlowTime>();
        timeDelay = normalSpeed;
        StartCoroutine(StartTimer(gameTimer));
    }

    public IEnumerator StartTimer(float timerValue)
    {
        timerValue = gameTimer;
        currentTimer = timerValue;
        gameTimer = timerValue;

        while (currentTimer > 0)
        {
            if (slowTime.isPowerUpActive)
            {
                timeDelay = slowSpeed;
            }
            else
            {
                timeDelay = normalSpeed;
            }

            yield return new WaitForSeconds(timeDelay);
            currentTimer--;
            timerText.text = currentTimer.ToString("0");
        }
    }

    public void UpdateScore()
    {
        if (overallScore < 0)
        {
            overallScore = 0;
        }

        overallScoreText.text = overallScore.ToString("0");
    }

    public void UpdateHits()
    {
        hitScoreText.text = hitScore.ToString("0");
    }
}
