using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public GameObject[] points;
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
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        if (this.gameObject.transform.position == targetPosition)
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
