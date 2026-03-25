using UnityEngine;
using UnityEngine.UI;

public class BackpackSystem : MonoBehaviour
{
    public int currentBagLevel = 1; // Starts from Level 1
    public int maxCapacity = 50;   // Base capacity
    public Text bagLevelDisplay;

    void Start()
    {
        UpdateBagCapacity();
    }

    // Call this when you find a Level 2 or Level 3 Bag on the map
    public void UpgradeBag(int newLevel)
    {
        if (newLevel > currentBagLevel)
        {
            currentBagLevel = newLevel;
            UpdateBagCapacity();
            Debug.Log("✔ BAG UPGRADED TO LEVEL " + currentBagLevel);
        }
    }

    void UpdateBagCapacity()
    {
        // Level 1: 50 Slots | Level 2: 100 Slots | Level 3: 150 Slots
        maxCapacity = currentBagLevel * 50;

        if (bagLevelDisplay != null)
            bagLevelDisplay.text = "BAG LVL: " + currentBagLevel + " (CAP: " + maxCapacity + ")";
        
        Debug.Log("Current Bag Level: " + currentBagLevel + " | Total Space: " + maxCapacity);
    }
}
