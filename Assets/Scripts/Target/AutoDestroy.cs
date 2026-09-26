using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
    public float currentTimer;
    public float autoDestoryTimer;
    Spawner manager;
    public bool doOnce;

    void Start()
    {
        manager = GetComponentInParent<Spawner>();
    }

    void Update()
    {
        if (manager.hasTargetSpawned && !doOnce)
        {
            StartCoroutine(StartTimer(autoDestoryTimer));
            doOnce = true;
        }
    }

    public IEnumerator StartTimer(float timerValue)
    {
        timerValue = autoDestoryTimer;
        currentTimer = timerValue;
        autoDestoryTimer = timerValue;

        while (currentTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTimer--;
            if (currentTimer == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
