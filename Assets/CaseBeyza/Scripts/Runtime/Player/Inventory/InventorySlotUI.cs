using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
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

    // ---------------- DRAG ----------------
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

    // ---------------- RIGHT CLICK ----------------
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentItem == null) return;

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DropToWorld();
        }
    }

    // ---------------- DROP (RAYCAST SAFE) ----------------
    void DropToWorld()
    {
        Vector3 camPos = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;

        Vector3 dropPos = camPos + forward * 2f;

        // zemini bul
        if (Physics.Raycast(camPos, Vector3.down, out RaycastHit hit, 10f))
        {
            dropPos = hit.point + Vector3.up * 0.15f;
        }

        Instantiate(
            currentItem.worldPrefab,
            dropPos,
            Quaternion.identity
        );

        InventoryManager.instance.RemoveItem(currentItem);
    }
}
