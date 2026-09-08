using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class Shoot : MonoBehaviour
{
    Camera playerCam;

    public float raycastRange;

    public string targetString;
    public string nonTargetString;

    public TMP_Text maxAmmoText;
    public TMP_Text currentAmmoText;
    public float maxAmmo;
    public float currentAmmo;
    public float reloadDelay;

    public bool isReloading;

    public void Start()
    {
        playerCam = Camera.main;
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        currentAmmoText.text = currentAmmo.ToString("0");
        maxAmmoText.text = maxAmmo.ToString("0");
    }

    public void fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray ray = playerCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (currentAmmo > 0 && !isReloading)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag(nonTargetString))
                    {

                    }
                    else if (hit.collider.CompareTag(targetString))
                    {
                        currentAmmo--;
                    }
                }
                else
                {
                    currentAmmo--;
                }
            }
            else if (currentAmmo <= 0)
            {
                Reload();
            }

            if (Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.collider.gameObject;

                TargetDestroy destory = target.GetComponent<TargetDestroy>();

                if (destory != null)
                {
                    destory.GetScore();
                }
            }
        }
    }

    public void Reload()
    {
        isReloading = true;
        StartCoroutine(ReloadDelay());
    }

    public IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
