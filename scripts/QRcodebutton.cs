using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class QRcodebutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Qrbutton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void backbutton()
    {
        SceneManager.LoadScene("Panel01");
    }
}
