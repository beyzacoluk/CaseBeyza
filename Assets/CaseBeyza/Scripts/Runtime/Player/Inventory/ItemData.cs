using UnityEngine;

[CreateAssetMenu(menuName = "inventory/item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject worldPrefab;
}
