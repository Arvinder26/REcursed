using UnityEngine;
using TMPro;

public class PlayerInteractionScript : MonoBehaviour
{

    [SerializeField]
    public Camera PlayerCamera;

    [SerializeField]
    public float InteractionDistance = 3;

    [SerializeField]
    public GameObject interactionText;
    private InteractObjectScript currentInteractable;

    void Update()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            InteractObjectScript interactableObject = hit.collider.GetComponent<InteractObjectScript>();
            if (interactableObject != null && interactableObject != currentInteractable)
            {
                currentInteractable = interactableObject;
                interactionText.SetActive(true);
                TextMeshProUGUI textComponent = interactionText.GetComponent<TextMeshProUGUI>();

                if (textComponent != null)
                {
                    textComponent.text = currentInteractable.GetInteractionText();
                }
            }
        }
        else
        {
            currentInteractable = null;
            interactionText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable?.Interact();
        }
    }
}
