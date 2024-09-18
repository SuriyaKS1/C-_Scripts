using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateCam : MonoBehaviour
{
    public float Speed;
    public float rotationSpeed = 50f;

    private bool isRotating = false;
    private Transform cameraTransform;
    public GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, Speed * Time.deltaTime, 0);
        }
        
    }
    public void Rotate()
    {
       // transform.Rotate(0, Speed * Time.deltaTime, 0);
       isRotating = !isRotating;
    
        

        //cameraTransform.RotateAround(transform.position, Vector3.up, 60f);

        //Vector3 rotationPoint = transform.position;
        //Vector3 rotationAxis = Vector3.up;
        //float rotationAngle = 60f;
        //Vector3 newCameraPosition = Quaternion.Euler(0, rotationAngle, 0) * (cameraTransform.position - rotationPoint) + rotationPoint;
        //StartCoroutine(SmoothlyMoveCamera(newCameraPosition));
        // Rotate the object around its Y axis
        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        //Vector3 rotationPoint = new Vector3(-7664,-4400,-4152);
        //transform.RotateAround(rotationPoint, Vector3.up, 60f);
         //_gameObject.transform.Rotate(0, Speed * Time.deltaTime, 0);
         //isRotating = !isRotating;
    }
    //private IEnumerator SmoothlyMoveCamera (Vector3 targetposition)
    //{
       // float timeElapsed = 0;
       // float duration = 1f;

       // while (timeElapsed < duration)
       // {
       //     cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetposition, timeElapsed/duration);
       //     timeElapsed += Time.deltaTime;
        //    yield return null;
        //}
    //}

    public void discription()
    {
        SceneManager.LoadScene("Discreption");
    }

    public void motorondis()
    {
        SceneManager.LoadScene("motorOn");
    }
    public  void motoroffdis()
    {
        SceneManager.LoadScene("motorOff");

    }
    public void motorStartdis()
    {
        SceneManager.LoadScene("motorStart");

    }
    public void motortopdis()
    {
        SceneManager.LoadScene("motorStop");

    }
     public void motorTrip()
    {
        SceneManager.LoadScene("motorTrip");
    }
    public void Ammeter()
    {
        SceneManager.LoadScene("Ammeter");
    }
    public void Voltmeter()
    {
        SceneManager.LoadScene("Voltmeter");
    }
    public void MCCB()
    {
        SceneManager.LoadScene("MCCB");
    }

} 
