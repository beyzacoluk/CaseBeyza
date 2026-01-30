using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool used;

    public virtual bool CanInteract()
    {
        return !used;
    }

    public virtual void Interact()
    {
        used = true;
        Debug.Log(gameObject.name + " ile etkileşim");
    }
}
