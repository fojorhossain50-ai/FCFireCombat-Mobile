using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchController : MonoBehaviour
{
    // Big Map: Titan Realm (55 Players)
    public void StartTitanRealm()
    {
        int totalPlayers = 55;
        Debug.Log("Loading Titan Realm... Survivors: " + totalPlayers);
        SceneManager.LoadScene("TitanRealm_Map");
    }

    // Small Map: Elite Clash (4 vs 4, Round System)
    public int currentRound = 1;
    public int maxRounds = 7;
    public int teamAScore = 0;
    public int teamBScore = 0;

    public void StartEliteClash()
    {
        Debug.Log("Starting Elite Clash: 4 vs 4 Squad Battle!");
        currentRound = 1;
        SceneManager.LoadScene("EliteClash_SmallMap");
    }

    public void FinishRound(string winningTeam)
    {
        if (winningTeam == "TeamA") teamAScore++;
        else teamBScore++;

        if (teamAScore >= 4 || teamBScore >= 4 || currentRound >= maxRounds)
        {
            DeclareChampion();
        }
        else
        {
            currentRound++;
            Debug.Log("Starting Round: " + currentRound);
        }
    }

    void DeclareChampion()
    {
        string finalWinner = teamAScore > teamBScore ? "TEAM A" : "TEAM B";
        Debug.Log("Match Over! Champion: " + finalWinner);
    }
}
