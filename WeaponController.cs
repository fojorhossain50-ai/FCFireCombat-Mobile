using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public int maxAmmo = 100;
    public float projectileSpeed = 20f;

    private float lastFireTime = 0f;
    private int currentAmmo;

    void Start() {
        currentAmmo = maxAmmo;
    }

    void Update() {
        HandleShooting();
    }

    void HandleShooting() {
        if (Input.GetMouseButton(0) && CanFire()) {
            Fire();
        }
    }

    bool CanFire() {
        return Time.time >= lastFireTime + fireRate && currentAmmo > 0;
    }

    void Fire() {
        if (projectilePrefab == null || firePoint == null) {
            Debug.LogError("ProjectilePrefab or FirePoint not assigned!");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null) {
            rb.velocity = firePoint.forward * projectileSpeed;
        }

        currentAmmo--;
        lastFireTime = Time.time;
    }

    public void RefillAmmo() {
        currentAmmo = maxAmmo;
    }

    public int GetCurrentAmmo() {
        return currentAmmo;
    }

    public int GetMaxAmmo() {
        return maxAmmo;
    }
}