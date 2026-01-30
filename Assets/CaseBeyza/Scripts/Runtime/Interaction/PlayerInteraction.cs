using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable currentInteractable;

    public GameObject ePanel;
    public Image progressFill;

    public float holdTime = 1.5f;

    private float holdTimer;

    void Update()
    {
        if (currentInteractable == null) return;

        if (Input.GetKey(KeyCode.E) && currentInteractable.CanInteract())
        {
            holdTimer += Time.deltaTime;
            progressFill.fillAmount = holdTimer / holdTime;

            if (holdTimer >= holdTime)
            {
                currentInteractable.Interact();
                ResetInteraction();
            }
        }
        else
        {
            ResetProgress();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            if (!interactable.CanInteract())
                return;

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
                ResetInteraction();
                currentInteractable = null;
            }
        }
    }

    void ResetProgress()
    {
        holdTimer = 0f;
        if (progressFill != null)
            progressFill.fillAmount = 0f;
    }

    void ResetInteraction()
    {
        ResetProgress();

        if (ePanel != null)
            ePanel.SetActive(false);
    }
}
