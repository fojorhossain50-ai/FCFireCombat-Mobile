using UnityEngine;
using System.Collections;

public class TitanShieldManager : MonoBehaviour
{
    public GameObject shieldPrefab; // The Wall Object
    public int shieldCount = 3;    // Start with 3 shields
    public float deployDistance = 2.5f;

    void Update()
    {
        // Press "G" to deploy Titan-Shield (Gloo Wall)
        if (Input.GetKeyDown(KeyCode.G) && shieldCount > 0)
        {
            DeployShield();
        }
    }

    void DeployShield()
    {
        shieldCount--;
        
        // Calculate position in front of player
        Vector3 spawnPos = transform.position + transform.forward * deployDistance;
        spawnPos.y = 0; // Stick to ground

        // Create the Shield
        GameObject wall = Instantiate(shieldPrefab, spawnPos, transform.rotation);
        
        Debug.Log("🛡️ TITAN-SHIELD DEPLOYED! Remaining: " + shieldCount);

        // Optional: Break the wall after 15 seconds
        Destroy(wall, 15f);
    }
}
