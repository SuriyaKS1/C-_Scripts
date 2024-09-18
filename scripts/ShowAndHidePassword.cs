using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowAndHidePassword : MonoBehaviour
{
    public InputField PasswordInputField;

    

    public Button showhide;

    private bool ShowPassword = false;
    // Start is called before the first frame update
   private void Start()
    {
        showhide.onClick.AddListener(TogglePasswordVisibility);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TogglePasswordVisibility()
    {
        ShowPassword = !ShowPassword;

        if (ShowPassword)
        {
            PasswordInputField.inputType = InputField.InputType.Standard;
        }
        else
        {
            PasswordInputField.inputType = InputField.InputType.Password;
        }
        PasswordInputField.ForceLabelUpdate();
    }
}
