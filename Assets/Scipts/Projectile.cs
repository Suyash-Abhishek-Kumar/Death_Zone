using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    public Text ammoText;

    [Header("Settings")]
    public int totalThrows = 30;
    public float throwCooldown;
    public int magazineSize = 10;
    public float reloadTime = 2f;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    private int currentAmmo;
    private bool isReloading = false;
    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
        currentAmmo = magazineSize;
        UpdateAmmoDisplay();
    }

    private void Update()
    {
        if (isReloading) return;
        if (Input.GetKey(throwKey) && readyToThrow && currentAmmo > 0)
        {
            Throw();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentAmmo < magazineSize && totalThrows > 0)
                Debug.Log("reloading");
                StartCoroutine(Reload());
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f, ~LayerMask.GetMask("Player", "Gun")))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        Debug.Log("ForceDirection: " + forceDirection + " Force: " + forceToAdd);

        currentAmmo--;
        UpdateAmmoDisplay();

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    System.Collections.IEnumerator Reload()
    {
        ReloadMessage();
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        int neededAmmo = magazineSize - currentAmmo;
        int ammoToLoad = Mathf.Min(neededAmmo, totalThrows);

        currentAmmo += ammoToLoad;
        // totalThrows -= ammoToLoad;

        Debug.Log("Reload complete. Ammo: " + currentAmmo + "/" + totalThrows);

        isReloading = false;
        UpdateAmmoDisplay();
    }

    void UpdateAmmoDisplay()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo + " / " + totalThrows;
        }
    }

    void ReloadMessage()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo + " / " + totalThrows + " || Reloading...";
        }
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
