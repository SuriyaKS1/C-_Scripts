using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loginpage : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField usernameInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;

    [SerializeField]
    private TextMeshProUGUI errorText;
    private TouchScreenKeyboard keyboard;

    bool isKeyboardOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (isKeyboardOpen && keyboard != null)
        {
            if (keyboard.status == TouchScreenKeyboard.Status.Done || keyboard.status == TouchScreenKeyboard.Status.Canceled)
            {
                if (usernameInputField.isFocused)
                {
                    usernameInputField.text = keyboard.text;
                }
                else if (passwordInputField.isFocused)
                {
                    passwordInputField.text = keyboard.text;
                }
            }
        }
    }

    public void OnSubmitLogin()
    {
        string username=usernameInputField.text;
        string password=passwordInputField.text;

        //check the username and password

        Debug.Log("USERNAME:" + username);
        Debug.Log("PASSWORD: "+ password);

       // SceneManager.LoadScene("SampleScene");

        string loginCheckMessage = CheckLoginInfo(username, password);
        if (string.IsNullOrEmpty(loginCheckMessage))
        {
            //Login
            Debug.Log("LOGIN");
            SceneManager.LoadScene("QRScanIntro");
        }
        else
        {
            Debug.Log( loginCheckMessage);
            errorText.text =  loginCheckMessage;
        }

    }
    private string CheckLoginInfo(string username, string password)
    {
        string returnString = "";

        if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))

        {
            returnString = "Username and Password was empty";
        }
        else if(string.IsNullOrEmpty(username))
        {
            returnString = "Username was empty";
        }
        else if(string.IsNullOrEmpty(password))
        {
            returnString = "Password was empty";
        } 
        else
        {
            returnString = "";
        }
        Debug.Log("RETURN STRING:" + returnString);
        return returnString;
    }
    public void OnUsernameInputFieldClick()
    {
        // Open keyboard for password field
        keyboard = TouchScreenKeyboard.Open(usernameInputField.text, TouchScreenKeyboardType.Default, false, false, false, false);
        isKeyboardOpen = true;
    }
    public void OnPasswordInputFieldClick()
    {
        keyboard = TouchScreenKeyboard.Open(passwordInputField.text, TouchScreenKeyboardType.Default, false, false, true, false);
        isKeyboardOpen = true;
    }
    public void backbutton()
    {
        Application.Quit();
    }
    
}
