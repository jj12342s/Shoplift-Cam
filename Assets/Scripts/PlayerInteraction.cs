using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Tooltip("How far the player can interact")]
    public float interactRange = 3f;

    [Tooltip("Player's camera used for raycasting")]
    public Camera playerCamera;

    [Tooltip("Parent GameObject of the UI prompt")]
    public GameObject promptUI;

    [Tooltip("Text component that displays the prompt message")]
    public Text promptText;

    private InteractableObject currentInteractable;

    void Update()
    {
        CheckForInteractable();

        if (currentInteractable != null && Input.GetKeyDown(currentInteractable.interactionKey))
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                promptUI.SetActive(true);
                promptText.text = $"Press {interactable.interactionKey} to {interactable.interactionPrompt}";
                return;
            }
        }

        currentInteractable = null;
        promptUI.SetActive(false);
    }
    public void EnterLocker(Vector3 lockerLocation)
    {
        transform.position = lockerLocation;
    }
    public void ExitLocker(Vector3 lockerLocation)
    {

    }
}
