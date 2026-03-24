using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    
    private Vector3 movementDirection = Vector3.zero;
    private Rigidbody rb;
    private VirtualJoystick joystick;

    void Start() {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<VirtualJoystick>();
        
        if (rb == null) {
            Debug.LogError("PlayerController requires a Rigidbody component!");
        }
        if (joystick == null) {
            Debug.LogWarning("No VirtualJoystick found in scene. Movement will not work.");
        }
    }

    void Update() {
        if (joystick != null) {
            movementDirection = joystick.GetInputDirection();
            
            // Rotate player towards movement direction
            if (movementDirection.magnitude > 0.1f) {
                RotateTowardsMouse();
            }
        }
    }

    void FixedUpdate() {
        if (rb != null) {
            // Apply movement
            Vector3 newPosition = rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }

    void RotateTowardsMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        
        if (groundPlane.Raycast(ray, out float enter)) {
            Vector3 hitPoint = ray.origin + ray.direction * enter;
            Vector3 directionToMouse = (hitPoint - transform.position).normalized;
            
            if (directionToMouse != Vector3.zero) {
                Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}