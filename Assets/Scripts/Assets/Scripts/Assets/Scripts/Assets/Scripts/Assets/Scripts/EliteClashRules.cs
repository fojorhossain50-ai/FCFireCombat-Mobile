using UnityEngine;

public class EliteClashRules : MonoBehaviour
{
    public int teamASurvivors = 4;
    public int teamBSurvivors = 4;

    public void OnPlayerEliminated(string teamName)
    {
        if (teamName == "TeamA")
        {
            teamASurvivors--;
        }
        else
        {
            teamBSurvivors--;
        }

        CheckRoundEnd();
    }

    void CheckRoundEnd()
    {
        if (teamASurvivors <= 0)
        {
            Debug.Log("Team B Wins the Round!");
            // Reset for next round logic here
        }
        else if (teamBSurvivors <= 0)
        {
            Debug.Log("Team A Wins the Round!");
        }
    }
}
