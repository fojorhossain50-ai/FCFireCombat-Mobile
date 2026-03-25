using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public InputField nameInputField;
    public Text displayNameText;
    private string playerName;

    void Start()
    {
        // Load the saved name if it exists
        playerName = PlayerPrefs.GetString("PlayerName", "NewBoss");
        UpdateDisplayName();
    }

    public void SaveNewName()
    {
        if (nameInputField != null && nameInputField.text != "")
        {
            playerName = nameInputField.text;
            // Save name permanently in the game
            PlayerPrefs.SetString("PlayerName", playerName);
            UpdateDisplayName();
            Debug.Log("Nickname updated to: " + playerName);
        }
    }

    void UpdateDisplayName()
    {
        if (displayNameText != null)
        {
            displayNameText.text = "WELCOME, " + playerName;
        }
    }
}
