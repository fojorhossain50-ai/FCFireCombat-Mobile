using UnityEngine;
using System.Collections;

public class TitanPlaneSystem : MonoBehaviour
{
    public float planeSpeed = 40f;
    public Vector3 startPoint = new Vector3(-500, 300, 0); // Starting in the sky
    public Vector3 endPoint = new Vector3(500, 300, 0);   // Ending at the other side
    
    private bool hasJumped = false;

    void Start()
    {
        // Place the plane at the start position in the sky
        transform.position = startPoint;
        Debug.Log("Plane is flying over Titan Realm...");
    }

    void Update()
    {
        // 1. Move the plane across the map
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);

        // 2. Press "J" or a Button to Jump (Free Fire Style)
        if (Input.GetKeyDown(KeyCode.J) && !hasJumped)
        {
            PerformJump();
        }
    }

    public void PerformJump()
    {
        hasJumped = true;
        Debug.Log("Player Jumped! Skydiving starts now...");
        
        // This is where we trigger the Skydive animation
        // and detach the player from the plane.
    }
}
