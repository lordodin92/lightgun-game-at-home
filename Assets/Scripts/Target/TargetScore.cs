using System.Collections;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public float maximumPoints;
    public float minimumPoints;
    public float targetScore;
    public float scoreDegradeTime;
    public float degradeDelay;

    void Start()
    {
        targetScore = maximumPoints;
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

}
