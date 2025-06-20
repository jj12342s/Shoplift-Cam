using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [Tooltip("The key the player must press to interact")]
    public KeyCode interactionKey = KeyCode.E;

    [Tooltip("Text that appears when looking at this object")]
    public string interactionPrompt = "Interact";

    [Tooltip("Event to trigger when the player interacts")]
    public UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }
}
