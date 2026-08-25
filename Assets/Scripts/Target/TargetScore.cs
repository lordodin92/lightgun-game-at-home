using System.Collections;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public float maximumPoints;
    public float minimumPoints;
    public float targetScore;
    public float scoreDegradeTime;

    void Start()
    {
        targetScore = maximumPoints;
    }

    public void StartTimer()
    {
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
