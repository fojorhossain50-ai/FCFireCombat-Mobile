using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EliteShopManager : MonoBehaviour
{
    public int playerCoins = 500; // Starting money for Round 1
    public Text coinDisplay;
    public GameObject shopPanel;

    void Start()
    {
        UpdateCoinUI();
        shopPanel.SetActive(false); // Shop is closed by default
    }

    public void OpenShop() { shopPanel.SetActive(true); }
    public void CloseShop() { shopPanel.SetActive(false); }

    // Call this when clicking a weapon button in the shop
    public void BuyWeapon(string weaponName, int price)
    {
        if (playerCoins >= price)
        {
            playerCoins -= price;
            UpdateCoinUI();
            Debug.Log("Successfully Bought: " + weaponName);
            // GiveWeaponToPlayer(weaponName);
        }
        else
        {
            Debug.Log("❌ NOT ENOUGH COINS FOR " + weaponName);
        }
    }

    void UpdateCoinUI()
    {
        if (coinDisplay != null)
            coinDisplay.text = "COINS: $" + playerCoins;
    }
}
