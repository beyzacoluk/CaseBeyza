using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI[] slots;

    public void Refresh()
    {
        var items = InventoryManager.instance.items;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].SetItem(items[i]);
            else
                slots[i].Clear();
        }
    }
}
