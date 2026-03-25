using UnityEngine;

public class LootVisuals : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bounceHeight = 0.2f;
    public float bounceSpeed = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        // Adding a glowing light to make it clear like Free Fire
        Light lootLight = gameObject.AddComponent<Light>();
        lootLight.range = 5f;
        lootLight.intensity = 2f;
        lootLight.color = Color.cyan; // Cyan glow for Titan-Restorer
    }

    void Update()
    {
        // 1. Make the item rotate (Style)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // 2. Make the item bounce up and down (Visibility)
        float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
 
