using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IEndDragHandler {
    public Image joystickBackground;
    public Image joystickStick;
    public float joystickRadius = 50f;
    public float deadZone = 0.1f;
    
    private Vector2 inputDirection = Vector2.zero;
    private Vector2 joystickCenter;

    void Start() {
        if (joystickBackground != null) {
            joystickCenter = joystickBackground.rectTransform.anchoredPosition;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        Vector2 direction = eventData.position - (Vector2)joystickBackground.transform.position;
        inputDirection = (direction.magnitude > joystickRadius) 
            ? direction.normalized 
            : direction / joystickRadius;

        // Apply dead zone
        if (inputDirection.magnitude < deadZone) {
            inputDirection = Vector2.zero;
        }

        // Update visual stick position
        if (joystickStick != null) {
            joystickStick.rectTransform.anchoredPosition = inputDirection * joystickRadius * 0.7f;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        inputDirection = Vector2.zero;
        
        // Reset stick visual to center
        if (joystickStick != null) {
            joystickStick.rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    public Vector3 GetInputDirection() {
        return new Vector3(inputDirection.x, 0, inputDirection.y).normalized;
    }

    public float GetInputMagnitude() {
        return inputDirection.magnitude;
    }
}