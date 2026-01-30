using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable currentInteractable;

    public GameObject ePanel; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact();

                if (ePanel != null)
                    ePanel.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            currentInteractable = interactable;

            if (ePanel != null)
                ePanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            if (currentInteractable == interactable)
            {
                currentInteractable = null;

                if (ePanel != null)
                    ePanel.SetActive(false);
            }
        }
    }
}
