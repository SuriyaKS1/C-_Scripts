using UnityEngine;
using UnityEngine.UI;

public class EnableDisable : MonoBehaviour
{
    // References to the buttons
    public Button startMotorButton;
    public Button greenButton;
    public Button redButton;
    public Button stopMotorButton;

    // References to the lights (GameObjects)
    public GameObject greenLight;
    public GameObject redLight;

    // Method to be called when Start Motor button is clicked
    public void StartMotorButtonClicked()
    {
        // Enable both green and red lights
        greenLight.SetActive(true);
        redLight.SetActive(true);

        // Enable the green and red buttons
        greenButton.interactable = true;
        redButton.interactable = true;
    }

    // Method to be called when Green button is clicked
    public void GreenButtonClicked()
    {
        // Enable green light and disable red light
        greenLight.SetActive(true);
        redLight.SetActive(false);
    }

    // Method to be called when Red button is clicked
    public void RedButtonClicked()
    {
        // Enable red light and disable green light
        redLight.SetActive(true);
        greenLight.SetActive(false);
    }

    // Method to be called when Stop Motor button is clicked
    public void StopMotorButtonClicked()
    {
        // Disable both green and red lights
        greenLight.SetActive(false);
        redLight.SetActive(false);

        // Disable the green and red buttons
        greenButton.interactable = false;
        redButton.interactable = false;
    }

    // Initialize the button states
    void Start()
    {
        // Initially disable the green and red buttons and lights
        greenButton.interactable = false;
        redButton.interactable = false;
        greenLight.SetActive(false);
        redLight.SetActive(false);
    }
}
