using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillFeedManager : MonoBehaviour
{
    public Text killFeedText;
    public float displayDuration = 3f;

    void Start()
    {
        if (killFeedText != null)
            killFeedText.text = ""; // Start with empty screen
    }

    // Call this when you eliminate someone
    public void OnEnemyEliminated(string playerName, string weaponUsed, string enemyName)
    {
        string message = "★ " + playerName + " ELIMINATED " + enemyName + " WITH " + weaponUsed + " ★";
        StartCoroutine(ShowKillMessage(message));
    }

    IEnumerator ShowKillMessage(string message)
    {
        if (killFeedText != null)
        {
            killFeedText.text = message;
            killFeedText.color = Color.red; // Like Free Fire red kill color
            
            yield return new WaitForSeconds(displayDuration);
            
            killFeedText.text = ""; // Hide after 3 seconds
        }
    }
}
