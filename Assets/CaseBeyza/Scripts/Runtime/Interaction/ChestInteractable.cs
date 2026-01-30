using UnityEngine;

public class ChestInteractable : Interactable
{
    public Animator animator;

    [Header("Item Spawn")]
    public GameObject itemPrefab;      // spawn edilecek item
    public Transform spawnPoint;       // item spawn noktası

    private bool m_opened;

    public override void Interact()
    {
        if (m_opened) return;

        m_opened = true;

        if (animator != null)
            animator.SetTrigger("Open");

        Debug.Log("Chest açıldı");

        SpawnItem();
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
