using UnityEngine;

public class GlobalAirdropManager : MonoBehaviour
{
    public GameObject airdropPrefab;
    public float spawnInterval = 30f; // Every 30 seconds a drop falls
    public float mapSize = 100f;

    void Start()
    {
        // Start dropping boxes repeatedly
        InvokeRepeating("SpawnAirdrop", 5f, spawnInterval);
    }

    void SpawnAirdrop()
    {
        // Random position on the map
        float randomX = Random.Range(-mapSize, mapSize);
        float randomZ = Random.Range(-mapSize, mapSize);
        Vector3 spawnPos = new Vector3(randomX, 50f, randomZ); // Drops from height 50

        Instantiate(airdropPrefab, spawnPos, Quaternion.identity);
        Debug.Log("A new Airdrop is falling at: " + spawnPos);
    }
}
