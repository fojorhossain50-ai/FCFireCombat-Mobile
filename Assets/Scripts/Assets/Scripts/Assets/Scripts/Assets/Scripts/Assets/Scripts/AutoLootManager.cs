using UnityEngine;

public class AutoLootManager : MonoBehaviour
{
    public float pickupRange = 2.0f; // Range to auto-pick items

    void Update()
    {
        // 1. Find all loot items nearby (Guns, Ammo, Titan-Restorer)
        GameObject[] lootItems = GameObject.FindGameObjectsWithTag("Loot");

        foreach (GameObject item in lootItems)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);

            // 2. If close enough, pick it up automatically
            if (distance <= pickupRange)
            {
                PickUpItem(item);
            }
        }
    }

    void PickUpItem(GameObject item)
    {
        string itemName = item.name;
        Debug.Log("✔ AUTO-LOOT: Picked up " + itemName);

        // Play a small 'Click' sound for feedback
        // AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        // Remove the item from the map after picking
        Destroy(item);
    }
}
