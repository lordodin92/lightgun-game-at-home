using System.Collections;
using UnityEngine;

public class ResizeTarget : MonoBehaviour
{
    Vector3 minScale;
    public Vector3 maxScale;

    public float speed;
    public float normalSpeed;
    public float slowSpeed;
    public float duration;

    private bool repeatable = true;

    public GameObject targetObject;
    public GameObject slowTimeButton;
    SlowTime slowTime;

    void Start()
    {
        slowTime = slowTimeButton.GetComponent<SlowTime>();

        Rotation();
    }

    IEnumerator Rotation()
    {
        minScale = targetObject.transform.localScale;
        
        while (repeatable)
        {
            yield return RepeatLerp(minScale, maxScale, duration);
            yield return RepeatLerp(maxScale, minScale, duration);
        }
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        if (slowTime.isPowerUpActive)
        {
            speed = slowSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            targetObject.transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
