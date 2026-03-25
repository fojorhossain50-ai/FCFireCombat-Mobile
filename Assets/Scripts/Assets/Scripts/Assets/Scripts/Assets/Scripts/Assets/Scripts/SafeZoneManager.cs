using UnityEngine;
using System.Collections;

public class SafeZoneManager : MonoBehaviour
{
    public Transform safeZoneCircle; // The Blue Circle
    public float shrinkRate = 0.5f;   // How fast it shrinks
    public float zoneDamage = 5f;    // 5 HP damage outside zone
    public float waitTime = 60f;     // Wait 1 minute before shrinking

    private bool isShrinking = false;

    void Start()
    {
        // Start the zone countdown
        StartCoroutine(ZoneRoutine());
    }

    IEnumerator ZoneRoutine()
    {
        Debug.Log("Safe Zone is stable for " + waitTime + " seconds.");
        yield return new WaitForSeconds(waitTime);
        
        isShrinking = true;
        Debug.Log("Warning! Safe Zone is shrinking!");
    }

    void Update()
    {
        // 1. Shrink the Zone Scale
        if (isShrinking && safeZoneCircle.localScale.x > 10f)
        {
            safeZoneCircle.localScale -= new Vector3(shrinkRate, 0, shrinkRate) * Time.deltaTime;
        }

        // 2. Damage Player if outside
        CheckPlayerOutsideZone();
    }

    void CheckPlayerOutsideZone()
    {
        float distance = Vector3.Distance(transform.position, safeZoneCircle.position);
        float zoneRadius = safeZoneCircle.localScale.x / 2;

        if (distance > zoneRadius)
        {
            ApplyZoneDamage();
        }
    }

    void ApplyZoneDamage()
    {
        // Calling your Health System to reduce 5 HP
        Debug.Log("Warning: Outside Safe Zone! Taking Damage...");
        // currentHealth -= zoneDamage * Time.deltaTime;
    }
}
