using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator component
    public string buttonName;  // Name of the button in the UI Canvas
    public string[] animationNames;  // Array of animation names to play
    public string animatorLayerName;  // Animator layer name
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
        int animatorLayerIndex = animator.GetLayerIndex(animatorLayerName);

        if (animatorLayerIndex == -1)
        {
            Debug.LogWarning($"Animator layer '{animatorLayerName}' not found.");
            return;
        }

        if (clickCount < animationNames.Length)
        {
            // Ensure animation state exists in the specified layer
            if (animator.HasState(animatorLayerIndex, Animator.StringToHash(animationNames[clickCount])))
            {
                animator.Play(animationNames[clickCount], animatorLayerIndex);
            }
            else
            {
                Debug.LogWarning($"Animation state '{animationNames[clickCount]}' not found in Animator layer '{animatorLayerName}'.");
            }

            clickCount++;
        }

        if (clickCount >= animationNames.Length)
        {
            clickCount = 0; // Reset the click count after the last animation
        }
    }
}
