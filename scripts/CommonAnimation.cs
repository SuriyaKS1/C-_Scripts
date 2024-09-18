using UnityEngine;
using UnityEngine.UI;

public class CommonAnimation : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator component
    public string buttonName;  // Name of the button in the UI Canvas
    public string[] animationNames;  // Array of animation names to play
    public string animatorLayerName = "Base Layer"; // Animator layer name (default to "Base Layer")
    public bool useBooleanParameter = false;  // Flag to use boolean parameter
    public string booleanParameterName;  // Name of the boolean parameter
    public bool resetClickCountAfterCycle = true;  // Flag to reset click count after cycle
    private int clickCount = 0; // Track the number of clicks

    void Start()
    {
        // Find the button in the UI Canvas by its name
        Button yourButton = GameObject.Find(buttonName)?.GetComponent<Button>();

        // Ensure the button and animator are assigned
        if (yourButton != null && animator != null)
        {
            // Add a listener to the button to call the PlayAnimation method when clicked
            yourButton.onClick.AddListener(HandleClick);
        }
        else
        {
            Debug.LogWarning("Button or Animator is not assigned properly.");
        }
    }

    void HandleClick()
    {
        if (animator != null)
        {
            clickCount++;

            int animatorLayerIndex = animator.GetLayerIndex(animatorLayerName);

            if (useBooleanParameter)
            {
                bool currentState = animator.GetBool(booleanParameterName);
                animator.SetBool(booleanParameterName, !currentState);

                // Ensure animation state exists in the specified layer
                if (!currentState && clickCount <= animationNames.Length)
                {
                    if (animator.HasState(animatorLayerIndex, Animator.StringToHash(animationNames[clickCount - 1])))
                    {
                        animator.Play(animationNames[clickCount - 1], animatorLayerIndex);
                    }
                    else
                    {
                        Debug.LogWarning($"Animation state '{animationNames[clickCount - 1]}' not found in Animator layer {animatorLayerName}.");
                    }
                }
            }
            else
            {
                // Ensure animation state exists in the specified layer
                if (clickCount <= animationNames.Length)
                {
                    if (animator.HasState(animatorLayerIndex, Animator.StringToHash(animationNames[clickCount - 1])))
                    {
                        animator.Play(animationNames[clickCount - 1], animatorLayerIndex);
                    }
                    else
                    {
                        Debug.LogWarning($"Animation state '{animationNames[clickCount - 1]}' not found in Animator layer {animatorLayerName}.");
                    }
                }

                if (clickCount == animationNames.Length && resetClickCountAfterCycle)
                {
                    clickCount = 0; // Reset click count after finishing the cycle
                }
            }
        }
        else
        {
            Debug.LogWarning("Animator is not assigned properly.");
        }
    }
}