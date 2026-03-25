using UnityEngine;

public class GlobalGameSettings : MonoBehaviour
{
    // Global Names for both Maps
    public static string medkitName = "Titan-Restorer";
    public static float medkitHealAmount = 40f;
    public static float playerMaxHealth = 100f;

    // Global Weapon Names
    public static string primaryWeapon = "Elite-Striker";
    public static string secondaryWeapon = "Side-Kick";

    void Awake()
    {
        // This ensures the settings are consistent across all scenes
        DontDestroyOnLoad(gameObject);
        Debug.Log("Global Settings Loaded: " + medkitName + " heals " + medkitHealAmount + " HP");
    }
}
