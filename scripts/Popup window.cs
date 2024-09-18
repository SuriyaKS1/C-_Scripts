using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popupwindow : MonoBehaviour
{
    public GameObject popupwindow;
    // Start is called before the first frame update
    void Start()
    {
        popupwindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider .gameObject == gameObject)
                {
                    popupwindow.SetActive(!popupwindow.activeSelf);
                }
            }
        } 
    }
   
}
