using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public GameObject[] points;
    public GameObject targetObject;
    int destPoint;
    public float speed;
    public float delay;

    private Vector3 targetPosition;

    void Start()
    {
        UpdateTarget();
    }

    void Update()
    {
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
        Debug.Log(destPoint);
    }
}
