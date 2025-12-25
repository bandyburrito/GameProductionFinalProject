using UnityEngine;
using TMPro; // Needed for the UI Text
using System.Collections;
using UnityEditor.ShaderGraph; // Needed for the 2-second wait (Coroutine)

public class BulletAmountUI : MonoBehaviour
{
    [Header("Settings")]
    public int maxAmmo = 10;
    public float reloadTime = 2f;

    [Header("UI Reference")]
    public TextMeshProUGUI ammoText; // Drag your text object here

    // Private variables to track state
    private int currentAmmo;
    private bool isReloading = false;

    void Start()
    {
        // Fill ammo and update screen at the start
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        // 1. If we are reloading, don't allow shooting
        if (isReloading)
            return;

        // 2. Check for fire button (Left Mouse Click)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        // Decrease ammo
        currentAmmo--;
        
        // Update the number on screen
        UpdateAmmoUI();

        // -- Add your actual shooting code here (Raycast or Instantiate) --
        Debug.Log("Bang!");

        if (currentAmmo <= 1)
        {
            ammoText.color = Color.red;
        }

        // 3. Check if we ran out of ammo
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    // This is a special function that can "wait" for time
    IEnumerator Reload()
    {
        isReloading = true;
        ammoText.text = "Reloading...";
        ammoText.color = Color.red;
        Debug.Log("Reloading...");

        // 4. Wait for 2 seconds
        yield return new WaitForSeconds(reloadTime);

        // Refill ammo
        currentAmmo = maxAmmo;
        isReloading = false;
        
        UpdateAmmoUI();
        Debug.Log("Ready to fire!");

        ammoText.color = Color.white;
    }

    void UpdateAmmoUI()
    {
        // Updates the text to show "5 / 10"
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
}