using UnityEngine;

public class DoorInteractable : Interactable
{
    public Animator animator;
    public ItemData requiredKey;    
    public GameObject needKeyText;   

    private bool isOpen;

    void Start()
    {
        if (needKeyText != null)
            needKeyText.SetActive(false);
    }

    public override bool CanInteract()
    {
        
        return InventoryManager.instance.HasItem(requiredKey);
    }

    public override void Interact()
    {
        if (!InventoryManager.instance.HasItem(requiredKey))
            return;

        isOpen = !isOpen;

        if (animator != null)
            animator.SetBool("Open", isOpen);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!InventoryManager.instance.HasItem(requiredKey))
        {
            if (needKeyText != null)
                needKeyText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (needKeyText != null)
            needKeyText.SetActive(false);
    }
}
