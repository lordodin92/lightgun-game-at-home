using System.Collections;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public float maximumPoints;
    public float minimumPoints;
    public float targetScore;
    public float scoreDegradeTime;
    public float degradeDelay;

    public GameObject goldenPointsObject;
    GoldenPoints goldenPoints;

    Spawner spawner;

    void Start()
    {
        targetScore = maximumPoints;
        spawner = GetComponentInParent<Spawner>();
        goldenPoints = goldenPointsObject.GetComponent<GoldenPoints>();
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
        if (goldenPoints.isPowerUpActive)
        {
            targetScore *= 2f;
        }

        spawner.manager.overallScore += targetScore;
        spawner.manager.UpdateScore();
    }

}
