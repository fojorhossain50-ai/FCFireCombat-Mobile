using UnityEngine;
using UnityEngine.UI;

public class TitanDefenseSystem : MonoBehaviour
{
    public int vestLevel = 0;   // 0 = No Vest
    public int helmetLevel = 0; // 0 = No Helmet
    public Text defenseStatusText;

    // Call this when player is hit by an enemy
    public float CalculateDamage(float originalDamage, bool isHeadshot)
    {
        float finalDamage = originalDamage;

        if (isHeadshot)
        {
            // Helmet reduces headshot damage: Lvl1 (10%), Lvl2 (25%), Lvl3 (50%)
            finalDamage -= (helmetLevel * 0.15f) * originalDamage;
            Debug.Log("Helmet Protected! New Damage: " + finalDamage);
        }
        else
        {
            // Vest reduces body damage: Lvl1 (15%), Lvl2 (30%), Lvl3 (45%)
            finalDamage -= (vestLevel * 0.15f) * originalDamage;
            Debug.Log("Vest Protected! New Damage: " + finalDamage);
        }

        return Mathf.Max(finalDamage, 0); // Damage can't be negative
    }

    public void UpgradeArmor(int level, bool isHelmet)
    {
        if (isHelmet) helmetLevel = level;
        else vestLevel = level;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (defenseStatusText != null)
            defenseStatusText.text = "VEST: LVL " + vestLevel + " | HELMET: LVL " + helmetLevel;
    }
}
