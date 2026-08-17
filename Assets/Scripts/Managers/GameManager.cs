using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTimer;
    public float gameTimer;

    public TMP_Text timerText;

    void Start()
    {
        StartCoroutine(StartTimer(gameTimer));
    }

    public IEnumerator StartTimer(float timerValue)
    {
        timerValue = gameTimer;
        currentTimer = timerValue;
        timerText.text = currentTimer.ToString("0");
        gameTimer = timerValue;

        while (currentTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTimer--;
        }
    }
}
