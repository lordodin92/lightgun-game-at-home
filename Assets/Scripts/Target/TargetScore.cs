using System.Collections;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public float maximumPoints;
    public float minimumPoints;
    public float targetScore;
    public float scoreDegradeTime;
    public float degradeDelay;

    Spawner spawner;

    void Start()
    {
        targetScore = maximumPoints;
        spawner = GetComponentInParent<Spawner>();
    }

    public void StartTimer()
    {
        StartCoroutine(DegradeDelay());
    }

    public IEnumerator DegradeDelay()
    {
        yield return new WaitForSeconds(degradeDelay);
        StartCoroutine(DegradeValue());
    }
    public IEnumerator DegradeValue()
    {
        while (targetScore > minimumPoints)
        {
            yield return new WaitForSeconds(scoreDegradeTime);
            targetScore--;
        }
    }

    public void UpdateScore()
    {
        spawner.manager.overallScore += targetScore;
        spawner.manager.UpdateScore();
    }

}
