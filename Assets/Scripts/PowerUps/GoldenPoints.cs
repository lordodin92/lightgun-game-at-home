using System.Collections;
using UnityEngine;

public class GoldenPoints : MonoBehaviour
{
    public bool isPowerUpActive;
    public bool doOnce;

    public float powerUpTime;
    public float currentTimer;

    public float powerUpAmmount;

    void Start()
    {
        doOnce = false;
        isPowerUpActive = false;
    }

    public void Use()
    {
        if (!doOnce && !isPowerUpActive && powerUpAmmount > 0)
        {
            isPowerUpActive = true;
            doOnce = true;
            powerUpAmmount--;
            StartCoroutine(StartTimer(powerUpTime));
        }
    }

    public IEnumerator StartTimer(float timerValue)
    {
        timerValue = powerUpTime;
        currentTimer = timerValue;
        powerUpTime = timerValue;

        while (currentTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTimer--;

            if (currentTimer == 0)
            {
                isPowerUpActive = false;
                doOnce = false;
            }
        }
    }

}
