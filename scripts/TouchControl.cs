using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 4f;
    private TouchController1 controls;
    private Coroutine zoomCoroutine;
    private Transform cameraTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new TouchController1();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Start()
    {
        controls.Touch.SecondaryTouch.started += _ => ZoomStart();
        controls.Touch.SecondaryTouch.canceled += _ => ZoomEnd();
    }
    private void ZoomStart(){
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }
    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine);
    }
    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;
        while(true)
        {
            distance = Vector2.Distance(controls.Touch.PrimaryFingerTouch.ReadValue<Vector2>(),
                        controls.Touch.SecondaryFingerTouch.ReadValue<Vector2>());
            
            if(distance > previousDistance)
            {
                Vector3 targetPosition = cameraTransform.position;
                targetPosition.z -= 1;
                cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPosition,Time.deltaTime * cameraSpeed);

            }
            else if(distance < previousDistance)
            {
                Vector3 targetPosition = cameraTransform.position;
                targetPosition.z += 1;
                //Camera.main.orthographicSize--;
                cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPosition,Time.deltaTime * cameraSpeed);
            }
            previousDistance = distance;
            yield return null;
        }
    }
}
