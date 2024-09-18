using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatetheObject : MonoBehaviour
{

    public Transform target;

    public float rotationspeed = 5f;

    private Vector2 lastTouchPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began )
            {
                lastTouchPosition = touch.position;

            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 deltaPosition = touch.position - lastTouchPosition;

                float rotationY = deltaPosition.x * rotationspeed * Time.deltaTime;

                transform.RotateAround(target.position,Vector3.up,rotationY);

                lastTouchPosition = touch.position;
            }

        }
    }
    
}
