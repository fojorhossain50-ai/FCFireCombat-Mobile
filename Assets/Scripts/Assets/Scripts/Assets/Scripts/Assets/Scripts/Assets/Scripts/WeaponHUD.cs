using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    public Text weaponNameText;
    public Text ammoCountText;

    private string currentWeapon = "Vortex-AR";
    private int currentAmmo = 30;
    private int reserveAmmo = 120;

    void Start()
    {
        // This will show same names in both maps
        UpdateWeaponUI();
    }

    public void UpdateWeaponUI()
    {
        if (weaponNameText != null)
            weaponNameText.text = currentWeapon;

        if (ammoCountText != null)
            ammoCountText.text = currentAmmo + " / " + reserveAmmo;
    }

    // Call this when shooting
    public void OnFire()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateWeaponUI();
        }
        else
        {
            Debug.Log("Out of Ammo! Reloading " + currentWeapon);
        }
    }
}
