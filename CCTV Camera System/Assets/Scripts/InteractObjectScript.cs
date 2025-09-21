using UnityEngine;
using UnityEngine.Events;

public class InteractObjectScript : MonoBehaviour
{
    public string interactionText = "Press E to Interact";
    public UnityEvent onInteract;

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        onInteract.Invoke();
    }
}
