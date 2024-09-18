using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public float Movespeed = 5f;
    public float lookspeed = .5f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }
    
    void Update()
    {
        Vector3 velocity = transform.right * Input.GetAxisRaw("Horizontal");
        velocity += transform.forward * Input.GetAxisRaw("Vertical");
        rb.velocity = Vector3.ClampMagnitude(velocity, 1) * Movespeed;
        transform.Rotate(transform.up, Input.GetAxis("Mouse X") * Mathf.Rad2Deg * Time.deltaTime * lookspeed);
        Camera.main.transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * Mathf.Rad2Deg * Time.deltaTime * lookspeed);
        float angle = Camera.main.transform.localEulerAngles.x;
        if (angle > 180)
            angle -= 360;
        if (angle < -180)
            angle += 360;
        angle = Mathf.Clamp(angle, -60f, 60f);
        Camera.main.transform.localEulerAngles = new Vector3(angle, 0, 0);
        Debug.Log("Velocity: " + velocity);
        Debug.Log("Rigidbody velocity: " + rb.velocity);
    }
}
