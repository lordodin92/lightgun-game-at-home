using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    public string outOfBoundTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(outOfBoundTag))
        {
            Destroy(this.gameObject);
        }
    }
}
