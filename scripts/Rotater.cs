using UnityEngine;

public class TouchRotator : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // The object to be rotated
    [SerializeField] private float rotationSpeed = 0.1f; // Speed of rotation

    private Vector2 previousTouchPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Initialize touch position
                previousTouchPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the amount of rotation
                Vector2 deltaTouchPosition = touch.position - previousTouchPosition;
                float yRotation = deltaTouchPosition.x * rotationSpeed * Time.deltaTime;

                // Rotate the target object only around the Y axis
                targetObject.transform.Rotate(Vector3.up, yRotation, Space.World);

                // Update previous touch position
                previousTouchPosition = touch.position;
            }
        }
    }
}
