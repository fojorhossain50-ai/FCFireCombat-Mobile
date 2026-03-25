using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MatchSummary : MonoBehaviour
{
    public GameObject summaryPanel; // The Table Background
    public Text playerNamesText;
    public Text killsText;
    public Text damageText;
    public Text headshotsText;

    // Use a list to store all player stats
    public void DisplayFinalStats(string[] names, int[] kills, float[] damage, int[] headshots)
    {
        summaryPanel.SetActive(true);
        
        playerNamesText.text = "PLAYER\n";
        killsText.text = "KILLS\n";
        damageText.text = "DAMAGE\n";
        headshotsText.text = "H.S.\n";

        for (int i = 0; i < names.Length; i++)
        {
            playerNamesText.text += names[i] + "\n";
            killsText.text += kills[i] + "\n";
            damageText.text += damage[i].ToString("F0") + "\n";
            headshotsText.text += headshots[i] + "\n";
        }
        
        Debug.Log("✔ Match Summary Table Displayed!");
    }
}
