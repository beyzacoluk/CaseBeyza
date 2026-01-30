using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable currentInteractable;
    private PickupItem currentPickup;

    public GameObject ePanel;
    public GameObject fPanel;   
    public Image progressFill;

    public float holdTime = 1.5f;
    private float holdTimer;

    void Start()
    {
        if (ePanel != null) ePanel.SetActive(false);
        if (fPanel != null) fPanel.SetActive(false);
    }

    void Update()
    {
        HandleInteract();
        HandlePickup();
    }

    
    void HandleInteract()
    {
        if (currentInteractable == null)
            return;

        if (Input.GetKey(KeyCode.E) && currentInteractable.CanInteract())
        {
            holdTimer += Time.deltaTime;

            if (progressFill != null)
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

    
    void HandlePickup()
    {
        if (currentPickup == null)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            InventoryManager.instance.AddItem(currentPickup.itemData);
            Destroy(currentPickup.gameObject);

            currentPickup = null;

            if (fPanel != null)
                fPanel.SetActive(false);
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        // interactable (chest, door)
        if (other.TryGetComponent(out Interactable interactable))
        {
            if (!interactable.CanInteract())
                return;

            currentInteractable = interactable;

            if (ePanel != null)
                ePanel.SetActive(true);
        }

        // pickup item
        if (other.TryGetComponent(out PickupItem pickup))
        {
            currentPickup = pickup;

            if (fPanel != null)
                fPanel.SetActive(true);
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

        if (other.TryGetComponent(out PickupItem pickup))
        {
            if (currentPickup == pickup)
            {
                currentPickup = null;

                if (fPanel != null)
                    fPanel.SetActive(false);
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
