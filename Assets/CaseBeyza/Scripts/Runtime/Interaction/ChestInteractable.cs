using UnityEngine;

public class ChestInteractable : Interactable
{
    public Animator animator;

    private bool opened;

    public override void Interact()
    {
        if (opened) return;

        opened = true;

        if (animator != null)
            animator.SetTrigger("Open");

        Debug.Log("chest acildi");
    }
}
