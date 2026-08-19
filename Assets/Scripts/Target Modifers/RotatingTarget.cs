using UnityEngine;

public class RotatingTarget : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject targetObject;

    private void Update()
    {
        targetObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
