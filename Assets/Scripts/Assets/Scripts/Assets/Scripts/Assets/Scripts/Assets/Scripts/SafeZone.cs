using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public float shrinkRate = 0.1f;
    public float minSize = 5f;
    public float damagePerSecond = 5f;

    void Update()
    {
        // Shrink the zone over time
        if (transform.localScale.x > minSize)
        {
            transform.localScale -= new Vector3(shrinkRate, 0, shrinkRate) * Time.deltaTime;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If player is outside the zone, they take damage
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is outside the Safe Zone! Taking Damage!");
        }
    }
}
