using UnityEngine;

public class RotatingTarget : MonoBehaviour
{
    public float rotationSpeed;
    public float normalSpeed;
    public float slowSpeed;
    public GameObject targetObject;
    public GameObject slowTimeButton;
    SlowTime slowTime;

    private void Start()
    {
        slowTime = slowTimeButton.GetComponent<SlowTime>();
        rotationSpeed = normalSpeed;
    }

    private void Update()
    {
        if (slowTime.isPowerUpActive)
        {
            rotationSpeed = slowSpeed;
        }
        else
        {
            rotationSpeed = normalSpeed;
        }

        targetObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
