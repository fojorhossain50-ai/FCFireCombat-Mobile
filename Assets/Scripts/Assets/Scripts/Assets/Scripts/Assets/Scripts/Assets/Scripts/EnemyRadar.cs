using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyRadar : MonoBehaviour
{
    public GameObject redDotPrefab; // The Red Dot Image
    public Transform miniMapUI;     // Your Mini-map Container
    public float indicatorDuration = 2.0f; // Red dot disappears after 2s

    // Call this function whenever an Enemy fires their weapon
    public void OnEnemyFire(Vector3 enemyPosition)
    {
        StartCoroutine(ShowRedDotOnMap(enemyPosition));
    }

    IEnumerator ShowRedDotOnMap(Vector3 pos)
    {
        // 1. Create a Red Dot on the Mini-map
        GameObject dot = Instantiate(redDotPrefab, miniMapUI);
        
        // 2. Position the dot relative to the enemy's world position
        dot.transform.localPosition = new Vector2(pos.x, pos.z); 

        Debug.Log("⚠️ WARNING: Enemy Firing Detected at: " + pos);

        // 3. Keep it visible for 2 seconds (Flash effect)
        yield return new WaitForSeconds(indicatorDuration);

        // 4. Remove the dot
        Destroy(dot);
    }
}
