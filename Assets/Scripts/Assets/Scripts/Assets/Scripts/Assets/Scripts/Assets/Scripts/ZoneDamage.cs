using UnityEngine;

public class ZoneDamage : MonoBehaviour
{
    public float damageAmount = 10f;
    public float damageInterval = 1f;
    private float nextDamageTime = 0f;
    private bool isInsideZone = true;

    void Update()
    {
        // If player is outside the zone, take damage every second
        if (!isInsideZone && Time.time >= nextDamageTime)
        {
            TakeZoneDamage();
            nextDamageTime = Time.time + damageInterval;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideZone = true;
            Debug.Log("Safe! You are inside the zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideZone = false;
            Debug.Log("Warning! Outside Zone! Taking Damage!");
        }
    }

    void TakeZoneDamage()
    {
        // Here we can link the player's health script
        Debug.Log("Health Decreasing due to Zone...");
    }
}
