using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1.5f;
    public float detectRange = 15f;
    private float nextFireTime = 0f;

    void Update()
    {
        // Search for Player or other Enemies to shoot
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            
            // If Player is in range, shoot!
            if (distance <= detectRange && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab != null && shootPoint != null)
        {
            Instantiate(enemyBulletPrefab, shootPoint.position, shootPoint.rotation);
            Debug.Log("Enemy Fired a shot!");
        }
    }
}
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1.5f;
    public float detectRange = 15f;
    private float nextFireTime = 0f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            
            if (distance <= detectRange && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab != null && shootPoint != null)
        {
            Instantiate(enemyBulletPrefab, shootPoint.position, shootPoint.rotation);
            Debug.Log("Enemy Fired!");
        }
    }
}
