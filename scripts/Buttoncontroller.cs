using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Buttoncontroller : MonoBehaviour
{
    public float openAngle = 90f;
   // public float closeAngle = 0f;
    public float smoothspeed = 2f;
     
    private bool isOpen = false;
    private Quaternion openRotation;
    private Quaternion closeRotation;
    private Quaternion initialRotation;
    Animator anim;
    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void _SetTouchLevel(float level);
    [DllImport("__Internal")]
    private static extern void _TurnOn();
    [DllImport("__Internal")]
    private static extern void _TurnOff();
    #endif
    public GameObject targetGameObject;
    public GameObject gameobject;   
    public Button button; 


    private void Start()
    {
        initialRotation = transform.localRotation;
       
        openRotation = Quaternion.Euler(0, openAngle, 0) * initialRotation;
        closeRotation = initialRotation;
        anim = gameObject.AddComponent<Animator>();
       
        // Add a listener to the button's onClick event
        //button.onClick.AddListener(PlayAnimation);
    

     
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        Quaternion targetRotation = isOpen ? openRotation : closeRotation;
        transform.localRotation = targetRotation;

        Debug.Log("Current Rotation:" + transform.localRotation.eulerAngles.y);

        Debug.Log("Toggledoor method called.....");
    }
    public void Backbutton()
    {
        SceneManager.LoadScene("SampleScene");
        //Application.Quit();
    }
    public void StopButton()
    {
        anim.SetTrigger("MotorStop");
    }
     public void StartButton()
    {
        anim.SetTrigger("MotoStart");
    }
     public void OnButton()
    {
        SceneManager.LoadScene("motorOn");
    }
     public void OffButton()
    {
        SceneManager.LoadScene("motorOff");
        
    } 
    public void TripButton()
    {
        SceneManager.LoadScene("motorTrip");
    } 
    public void AmmeterButton()
    {
        SceneManager.LoadScene("Ammeter");
    } 
    //public void PlayAnimation()
    //{
      //  if(anim != null && button != null)
        //{
          //  anim.SetTrigger("frontdoorOpen");
        //}
            
         //else
        //{
          //  Debug.LogError("One or both of animator and button are null!");
        //}
    //}
    public void MCCBANIM()
    {
        anim.SetBool("mccbbool",true);
        anim.Play("MCCB");
    }
    public void VDiscriptionButton()
    {
        SceneManager.LoadScene("Voltmeter");
    } 
    public void MccbButton()
    {
        SceneManager.LoadScene("MCCB");
    }
    public void EmergencyOpen()
    {
        anim.SetTrigger("EmergencyCapOpen");
    }
   
    public void StartSwitch()
    {
        anim.SetTrigger("MotoStart");
    }
    public void StopSwitch()
    {
        anim.SetTrigger("MotorStop");
    }
    public void MBBCSwitch()
    {
        anim.SetTrigger("mccbbool");
        anim.Play("MCCB");
    }
    public void OpenCloseButton()
    {
        anim.SetTrigger("a1");
    }
    

    public void ToggleParent()
    {
        // Check if the current GameObject has a parent
        if (transform.parent != null)
        {
            // Get the parent GameObject
            GameObject parentObject = transform.parent.gameObject;

            // Check if the parent is active in the hierarchy
            if (parentObject.activeInHierarchy)
            {
                // Parent is active, so disable it
                parentObject.SetActive(false);
                Debug.Log("Parent has been disabled.");
            }
            else
            {
                // Parent is not active, so enable it
                parentObject.SetActive(true);
                Debug.Log("Parent has been enabled.");
            }
        }
        else
        {
            Debug.LogWarning("This GameObject has no parent and is likely a root object.");
        }
    }
    
       
}


