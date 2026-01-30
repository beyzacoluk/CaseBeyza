using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Transform inventoryUIParent;
    public GameObject inventorySlotPrefab;

    private List<PickupItem> items = new List<PickupItem>();
    private PickupItem currentItem;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentItem != null)
        {
            AddItem(currentItem);
        }
    }

    void AddItem(PickupItem item)
    {
        items.Add(item);

        GameObject slot = Instantiate(inventorySlotPrefab, inventoryUIParent);
        slot.GetComponent<InventorySlotUI>().Setup(item);

        Destroy(item.gameObject);
        currentItem = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickupItem item))
        {
            currentItem = item;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PickupItem item))
        {
            if (currentItem == item)
                currentItem = null;
        }
    }

    public void DropItem(PickupItem item)
    {
        items.Remove(item);
        Instantiate(item.worldPrefab, transform.position + transform.forward, Quaternion.identity);
    }
}
