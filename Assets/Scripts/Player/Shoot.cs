using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    Camera playerCam;

    public float raycastRange;

    public string targetString;

    public void Start()
    {
        playerCam = Camera.main;
    }

    public void fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray ray = playerCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.collider.gameObject;
                TargetDestroy destory = target.GetComponent<TargetDestroy>();
                if (destory != null)
                {
                    destory.GetScore();
                }
                else
                {
                    Debug.Log("NO TARGET");
                }
            }
        }
    }
}
