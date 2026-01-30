using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    private PickupItem item;

    public void Setup(PickupItem newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
    }

    public void OnClick()
    {
        InventoryManager.instance.DropItem(item);
        Destroy(gameObject);
    }
}
