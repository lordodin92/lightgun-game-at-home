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
    public string blockerString;

    public TMP_Text maxAmmoText;
    public TMP_Text currentAmmoText;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadDelay;
    public bool isReloading;

    public GameObject uimanager;
    public GameObject unlimitedBulletsButton;
    public GameObject blockerBusterButton;
    public GameObject piercingButton;
    UIManager manager;
    UnlimitedBullets unlimitedBullets;
    BlockerBuster blockerBuster;
    Piercing piercing;

    public LayerMask IgnoreMask;
    public LayerMask HitMask;

    public void Start()
    {
        playerCam = Camera.main;

        manager = uimanager.GetComponent<UIManager>();

        unlimitedBullets = unlimitedBulletsButton.GetComponent<UnlimitedBullets>();

        blockerBuster = blockerBusterButton.GetComponent<BlockerBuster>();

        piercing = piercingButton.GetComponent<Piercing>();

        while (currentAmmo < maxAmmo)
        {
            manager.BulletEnable(currentAmmo);
            currentAmmo++;
        }
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
                        if (!unlimitedBullets.isPowerUpActive)
                        {
                            currentAmmo--;
                            manager.BulletDecrease(currentAmmo);
                        }
                    }
                    else if (hit.collider.CompareTag(blockerString))
                    {
                        currentAmmo--;
                        manager.BulletDecrease(currentAmmo);
                    }
                }
                else
                {
                    if (!unlimitedBullets.isPowerUpActive)
                    {
                        currentAmmo--;
                        manager.BulletDecrease(currentAmmo);
                    }
                }
            }
            else if (currentAmmo <= 0)
            {
                Reload();
            }

            if (piercing.isPowerUpActive && Physics.Raycast(ray, out hit, Mathf.Infinity, ~IgnoreMask))
            {
                GameObject target = hit.collider.gameObject;

                TargetDestroy destory = target.GetComponent<TargetDestroy>();

                if (hit.collider.CompareTag(targetString))
                {
                    if (destory != null)
                    {
                        destory.GetScore();
                    }
                }

            }
            else if (Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.collider.gameObject;

                TargetDestroy destory = target.GetComponent<TargetDestroy>();
                TargetScore score = target.GetComponent<TargetScore>();

                if (hit.collider.CompareTag(blockerString) && score != null)
                {
                    if (blockerBuster.isPowerUpActive)
                    {
                        score.BlockerScore();
                        destory.destoryTarget();
                    }
                    else
                    {
                        score.DecreaseScore();
                    }
                }
                else if (destory != null)
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

        while(currentAmmo < maxAmmo)
        {
            manager.BulletIncrease(currentAmmo);
            currentAmmo++;
        }

        isReloading = false;
    }
}
