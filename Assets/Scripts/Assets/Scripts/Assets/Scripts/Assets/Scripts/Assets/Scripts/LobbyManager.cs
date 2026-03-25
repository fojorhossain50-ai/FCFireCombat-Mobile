using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LobbyManager : MonoBehaviour
{
    public int totalPlayersInLobby = 55;
    public float waitTime = 30f; // 30 seconds timer
    public Text lobbyTimerText;
    public Text playerCountText;

    void Start()
    {
        UpdateLobbyUI();
        StartCoroutine(StartLobbyCountdown());
    }

    void UpdateLobbyUI()
    {
        if (playerCountText != null)
            playerCountText.text = "PLAYERS JOINED: " + totalPlayersInLobby + " / 55";
    }

    IEnumerator StartLobbyCountdown()
    {
        float timeLeft = waitTime;

        while (timeLeft > 0)
        {
            if (lobbyTimerText != null)
                lobbyTimerText.text = "MATCH STARTING IN: " + Mathf.Round(timeLeft) + "s";
            
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        // After 30s, jump to the Big Map (Titan Realm)
        Debug.Log("Lobby Full! Entering Titan Realm...");
        SceneManager.LoadScene("TitanRealm");
    }
}
