using UnityEngine;

public class LootItem : MonoBehaviour
{
    public string itemName;
    public enum ItemType { Weapon, Medkit, Ammo }
    public ItemType type;

    void OnTriggerEnter(Collider other)
    {
        // If player touches the loot, pick it up
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        Debug.Log("Picked up: " + itemName);
        
        // Add logic for what happens after picking up
        if (type == ItemType.Weapon)
        {
            Debug.Log("Equipping Weapon...");
        }

        // Remove the item from the map
        Destroy(gameObject);
    }
}
