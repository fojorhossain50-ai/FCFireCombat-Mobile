using UnityEngine;
using System.Collections;

public class SkydiveController : MonoBehaviour
{
    public float fallSpeed = 20f;
    public float parachuteSpeed = 5f;
    public float parachuteHeight = 50f; // Height to open parachute automatically
    
    private bool isParachuteOpen = false;
    private bool isLanded = false;

    void Update()
    {
        if (isLanded) return;

        // 1. Get current height from ground
        float currentHeight = transform.position.y;

        // 2. Free Fall or Parachute Descent
        if (!isParachuteOpen)
        {
            // Falling fast (Diving)
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // Auto-open parachute at 50m height
            if (currentHeight <= parachuteHeight)
            {
                OpenParachute();
            }
        }
        else
        {
            // Floating down slowly
            transform.Translate(Vector3.down * parachuteSpeed * Time.deltaTime);
        }

        // 3. Ground Landing Logic
        if (currentHeight <= 1.0f) // If very close to ground
        {
            OnLand();
        }
    }

    public void OpenParachute()
    {
        if (!isParachuteOpen)
        {
            isParachuteOpen = true;
            Debug.Log("Parachute Opened! Gliding to Titan Realm...");
        }
    }

    void OnLand()
    {
        isLanded = true;
        Debug.Log("Landed Safely! Start Looting!");
        // Enable player movement and looting system here
    }
}
