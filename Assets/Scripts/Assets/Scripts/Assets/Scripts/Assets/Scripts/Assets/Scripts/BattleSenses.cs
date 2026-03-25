using UnityEngine;
using UnityEngine.UI;

public class BattleSenses : MonoBehaviour
{
    public AudioSource footstepSource;
    public GameObject redDotIcon; // Red Dot for Mini-map
    public Transform miniMapUI;

    // 1. Play 3D Footstep Sound
    public void PlayFootstep(Vector3 enemyPos)
    {
        // This will make sound come from the Enemy's direction (Left/Right)
        AudioSource.PlayClipAtPoint(footstepSource.clip, enemyPos);
        Debug.Log("👣 Sound: Enemy walking near " + enemyPos);
    }

    // 2. Show Red Dot when Enemy Fires
    public void OnEnemyFire(Vector3 firePos)
    {
        GameObject dot = Instantiate(redDotIcon, miniMapUI);
        
        // Convert World Position to Mini-map Position
        dot.transform.localPosition = new Vector2(firePos.x, firePos.z);
        
        Debug.Log("🔴 Map Alert: Enemy Firing at " + firePos);
        Destroy(dot, 2.0f); // Auto-remove after 2 seconds
    }
}
