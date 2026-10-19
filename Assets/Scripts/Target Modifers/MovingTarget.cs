using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public GameObject[] points;
    public GameObject targetObject;
    int destPoint;
    public float speed;
    public float normalSpeed;
    public float slowSpeed;
    public float delay;

    private Vector3 targetPosition;

    public GameObject slowTimeButton;
    SlowTime slowTime;

    void Start()
    {
        slowTime = slowTimeButton.GetComponent<SlowTime>();
        speed = normalSpeed;
        UpdateTarget();
    }

    void Update()
    {
        if (slowTime.isPowerUpActive)
        {
            speed = slowSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, targetPosition, speed * Time.deltaTime);
        if (targetObject.transform.position == targetPosition)
        {
            UpdateTarget();
        }
    }

    void UpdateTarget()
    {
        if (points.Length == 0)
        {
            return;
        }

        targetPosition = points[destPoint].transform.position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
