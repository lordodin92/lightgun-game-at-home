using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject[] points;
    public float[] timeMilestones;
    public GameObject player;
    int destPoint;
    int milestones;
    private float speed;
    private float rotationSpeed;
    public float normalSpeed;
    public float normalRotationSpeed;
    public float slowSpeed;
    public float slowRotationSpeed;
    public float delay;
    private float currentTime;

    private Vector3 targetPosition;
    private Transform targetRotation;
    public GameObject slowTimeButton;
    SlowTime slowTime;

    public GameObject gameManager;
    GameManager manager;

    void Start()
    {
        slowTime = slowTimeButton.GetComponent<SlowTime>();
        manager = gameManager.GetComponent<GameManager>();
        speed = normalSpeed;
        rotationSpeed = normalRotationSpeed;
        UpdateTarget();
        UpdateTime();
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

        if (player.transform.position == targetPosition && manager.currentTimer == currentTime)
        {
            UpdateTarget();
            UpdateTime();
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

    void UpdateTime()
    {
        if (timeMilestones.Length == 0)
        {
            return;
        }

        currentTime = timeMilestones[milestones];
        milestones = (milestones + 1) % timeMilestones.Length;
    }
}
