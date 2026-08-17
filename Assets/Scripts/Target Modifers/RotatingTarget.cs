using UnityEngine;

public class RotatingTarget : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
        this.gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
