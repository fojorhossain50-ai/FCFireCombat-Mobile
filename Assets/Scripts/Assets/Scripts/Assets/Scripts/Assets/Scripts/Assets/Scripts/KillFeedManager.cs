using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillFeedManager : MonoBehaviour
{
    public Text killFeedText;
    public float displayDuration = 3f;

    public void ShowKill(string killer, string victim)
    {
        string message = killer + " eliminated " + victim;
        killFeedText.text = message;
        Debug.Log(message);
        
        // Hide the message after a few seconds
        StartCoroutine(ClearText());
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(displayDuration);
        killFeedText.text = "";
    }
}
