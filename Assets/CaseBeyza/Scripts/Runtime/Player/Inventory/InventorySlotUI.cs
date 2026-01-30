using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image iconImage;
    public ItemData currentItem;

    private Canvas canvas;
    private Vector3 startPos;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        startPos = transform.position;
    }

    public void SetItem(ItemData item)
    {
        currentItem = item;
        iconImage.sprite = item.icon;
        iconImage.enabled = true;
    }

    public void Clear()
    {
        currentItem = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        transform.position += (Vector3)eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;

        if (!RectTransformUtility.RectangleContainsScreenPoint(
            canvas.transform as RectTransform,
            eventData.position))
        {
            DropToWorld();
        }

        transform.position = startPos;
    }

    void DropToWorld()
    {
        Instantiate(
            currentItem.worldPrefab,
            Camera.main.transform.position + Camera.main.transform.forward * 2f,
            Quaternion.identity
        );

        InventoryManager.instance.RemoveItem(currentItem);
    }
}
