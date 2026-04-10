using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject loadingScreen;

    [Header("Configuration")]
    public string gameMapName = "SampleScene";

    private void Awake()
    {
        InitializeLobby();
    }

    private void InitializeLobby()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        if (loadingScreen != null) loadingScreen.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        if (loadingScreen != null) loadingScreen.SetActive(true);
        SceneManager.LoadScene(gameMapName);
    }

    public void OnSettingsButtonClick()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OnBackToMenuClick()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }
}
