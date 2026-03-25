using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public Transform player; // Your Player
    public float mapHeight = 100f; // Height of the map camera

    void LateUpdate()
    {
        if (player == null) return;

        // 1. Follow the player's position on the map
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // Keep the camera at its fixed height
        transform.position = newPosition;

        // 2. Rotate the map with the player (Optional: Free Fire Style)
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
