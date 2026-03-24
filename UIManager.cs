using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text healthText;
    public Text ammoText;
    public Text scoreText;
    public Image healthBar;
    
    private PlayerController playerController;
    private WeaponController weaponController;
    private int score = 0;
    private int playerMaxHealth = 100;

    void Start() {
        playerController = FindObjectOfType<PlayerController>();
        weaponController = FindObjectOfType<WeaponController>();
        
        if (playerController == null) {
            Debug.LogError("PlayerController not found in scene!");
        }
        if (weaponController == null) {
            Debug.LogError("WeaponController not found in scene!");
        }
    }

    void Update() {
        UpdateHealthDisplay();
        UpdateAmmoDisplay();
        UpdateScoreDisplay();
    }

    void UpdateHealthDisplay() {
        if (playerController != null) {
            int currentHealth = playerController.GetHealth();
            healthText.text = "Health: " + currentHealth + "/" + playerMaxHealth;
            
            if (healthBar != null) {
                healthBar.fillAmount = (float)currentHealth / playerMaxHealth;
            }
        }
    }

    void UpdateAmmoDisplay() {
        if (weaponController != null) {
            int currentAmmo = weaponController.GetCurrentAmmo();
            int maxAmmo = weaponController.GetMaxAmmo();
            ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
        }
    }

    void UpdateScoreDisplay() {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int points) {
        score += points;
    }

    public int GetScore() {
        return score;
    }

    public void ResetScore() {
        score = 0;
    }
}