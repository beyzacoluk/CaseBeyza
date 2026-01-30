using UnityEngine;

public class ChestInteractable : Interactable
{
    public Animator animator;

    [Header("Item Spawn")]
    public GameObject itemPrefab;      
    public Transform spawnPoint;       

    private bool m_opened;
    private Collider m_collider;

    void Awake()
    {
        m_collider = GetComponent<Collider>();
        if (m_collider == null)
            Debug.LogWarning("ChestInteractable: Collider bulunamadı!");
    }

    public override void Interact()
    {
        if (m_opened) return;

        m_opened = true;

        if (animator != null)
            animator.SetTrigger("Open");

        Debug.Log("Chest açıldı");

        SpawnItem();

        
        if (m_collider != null)
            m_collider.enabled = false;
    }

    void SpawnItem()
    {
        if (itemPrefab == null)
        {
            Debug.LogWarning("ChestInteractable: Item prefab atanmadı!");
            return;
        }

        Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.up * 1f;

        Instantiate(itemPrefab, pos, Quaternion.identity);
    }
}
