using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalEnemies = 49;
    public Text aliveCountText;

    void Update()
    {
        // Display players alive on screen
        if (aliveCountText != null)
        {
            aliveCountText.text = "Alive: " + (totalEnemies + 1);
        }
    }

    public void EnemyKilled()
    {
        // Decrease enemy count when one dies
        totalEnemies--;
        Debug.Log("Enemy eliminated! Remaining: " + totalEnemies);
    }
}
