using UnityEngine;

public class PinchToZoomAndPan : MonoBehaviour
{
    public Camera _camera;  // Reference to the camera
    public Transform target;  // The target object to zoom in/out and pan around
    public float zoomSpeed = 0.1f;  // Speed of zooming
    public float panSpeed = 0.5f;  // Speed of panning
    public float minZoomDistance = 2f;  // Minimum distance between camera and target
    public float maxZoomDistance = 20f;  // Maximum distance between camera and target

    private float initialTouchDistance;
    private Vector3 initialCameraPosition;

    void Start()
    {
        // Ensure the camera is assigned
        if (_camera == null)
        {
            _camera = Camera.main;  // Assign the main camera if none is assigned
        }

        initialCameraPosition = _camera.transform.position;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Calculate the difference in the distance between the touches in each frame
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Difference in magnitudes between the previous and current positions
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Zoom the camera by moving it closer or further from the target
            float zoomAmount = deltaMagnitudeDiff * zoomSpeed * Time.deltaTime;
            _camera.transform.Translate(0, 0, zoomAmount, Space.Self);

            // Clamp the zoom to prevent the camera from getting too close or too far
            float distance = Vector3.Distance(_camera.transform.position, target.position);
            if (distance < minZoomDistance)
            {
                _camera.transform.position = target.position - (_camera.transform.forward * minZoomDistance);
            }
            else if (distance > maxZoomDistance)
            {
                _camera.transform.position = target.position - (_camera.transform.forward * maxZoomDistance);
            }

            // Panning the camera
            Vector2 touchDelta = (touchZero.deltaPosition + touchOne.deltaPosition) / 2;
            _camera.transform.Translate(-touchDelta.x * panSpeed * Time.deltaTime, -touchDelta.y * panSpeed * Time.deltaTime, 0);
        }
    }
}
