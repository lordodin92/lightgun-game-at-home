using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject[] points;
    public GameObject player;
    int destPoint;
    private float speed;
    private float rotationSpeed;
    public float normalSpeed;
    public float normalRotationSpeed;
    public float slowSpeed;
    public float slowRotationSpeed;
    public float delay;

    private Vector3 targetPosition;
    private Transform targetRotation;
    public GameObject slowTimeButton;
    SlowTime slowTime;

    void Start()
    {
        slowTime = slowTimeButton.GetComponent<SlowTime>();
        speed = normalSpeed;
        rotationSpeed = normalRotationSpeed;
        UpdateTarget();
    }

    void Update()
    {
        if (slowTime.isPowerUpActive)
        {
            speed = slowSpeed;
            rotationSpeed = normalRotationSpeed;
        }
        else
        {
            speed = normalSpeed;
            rotationSpeed = slowRotationSpeed;
        }

        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation.rotation, rotationSpeed * Time.deltaTime);

        if (player.transform.position == targetPosition)
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
        targetRotation = points[destPoint].transform;
        destPoint = (destPoint + 1) % points.Length;
    }
}
