using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [Header("settings")]
    public int maxSlots = 12;

    [Header("references")]
    public GameObject inventoryPanel;
    public Transform slotsParent;

    public List<ItemData> items = new List<ItemData>();

    bool isOpen;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        inventoryPanel.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

  
    public void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        Cursor.visible = isOpen;
        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }

   
    public void AddItem(ItemData item)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log("inventory dolu");
            return;
        }

        items.Add(item);
        RefreshUI();
    }

    
    public void RemoveItem(ItemData item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            RefreshUI();
        }
    }

    void RefreshUI()
    {
        InventorySlotUI[] slots =
            slotsParent.GetComponentsInChildren<InventorySlotUI>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].SetItem(items[i]);
            }
            else
            {
                slots[i].Clear(); 
            }
        }
    }
}
