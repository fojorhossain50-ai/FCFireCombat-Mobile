using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteHeadshotSystem : MonoBehaviour
{
    public Text headshotFeedText;
    public Image headshotIcon; // A Skull or Target Icon
    public float displayTime = 3f;

    void Start()
    {
        if (headshotFeedText != null) headshotFeedText.text = "";
        if (headshotIcon != null) headshotIcon.enabled = false;
    }

    // Call this specifically for Headshots
    public void ShowHeadshotKill(string killerName, string victimName, string weaponName)
    {
        string message = "⚡ HEADSHOT: " + killerName + " ⇛ " + victimName + " [" + weaponName + "]";
        StopAllCoroutines();
        StartCoroutine(DisplayHeadshot(message));
    }

    IEnumerator DisplayHeadshot(string msg)
    {
        if (headshotFeedText != null)
        {
            headshotFeedText.text = msg;
            headshotFeedText.color = Color.yellow; // Golden color for Headshot
            if (headshotIcon != null) headshotIcon.enabled = true;

            yield return new WaitForSeconds(displayTime);

            headshotFeedText.text = "";
            if (headshotIcon != null) headshotIcon.enabled = false;
        }
    }
}
