using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public int teamAScore = 0;
    public int teamBScore = 0;
    public int winningRounds = 4; // First to win 4 rounds wins match
    
    public Text scoreText; // Display like "3 - 2"
    public GameObject winScreen;

    void Start()
    {
        UpdateScoreUI();
        winScreen.SetActive(false);
    }

    // Call this when Team A wipes out Team B
    public void TeamAWinsRound()
    {
        teamAScore++;
        UpdateScoreUI();
        CheckMatchWinner();
    }

    // Call this when Team B wipes out Team A
    public void TeamBWinsRound()
    {
        teamBScore++;
        UpdateScoreUI();
        CheckMatchWinner();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = teamAScore + "  -  " + teamBScore;
    }

    void CheckMatchWinner()
    {
        if (teamAScore >= winningRounds)
        {
            Debug.Log("🏆 TEAM A IS THE CHAMPION!");
            ShowWinScreen("TEAM A VICTORIOUS!");
        }
        else if (teamBScore >= winningRounds)
        {
            Debug.Log("🏆 TEAM B IS THE CHAMPION!");
            ShowWinScreen("TEAM B VICTORIOUS!");
        }
    }

    void ShowWinScreen(string message)
    {
        winScreen.SetActive(true);
        // You can add a 'BOOYAH' or 'VICTORY' text here
    }
}
