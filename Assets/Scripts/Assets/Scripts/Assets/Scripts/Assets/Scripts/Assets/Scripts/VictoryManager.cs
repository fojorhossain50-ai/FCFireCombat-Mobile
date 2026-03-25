using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryManager : MonoBehaviour
{
    public Text victoryText;
    public GameObject victoryScreen;

    void Start()
    {
        if (victoryScreen != null) victoryScreen.SetActive(false);
    }

    // Call this when the match ends
    public void ShowVictory()
    {
        if (victoryScreen != null)5
        {
            victoryScreen.SetActive(true);
            victoryText.text = "ELITE DOMINATION!";
            victoryText.color = Color.yellow; // Golden Victory
            Debug.Log("Match Over: ELITE DOMINATION!");
        }
    }
}
