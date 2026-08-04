using UnityEngine;

public enum ItemType
{
    Resourse,
    Weapon,
    Tool,
    placeable,
    consumable,
    backpack
}
public enum ToolType
{
    axe,
    pickae,
    sheers,

}

[CreateAssetMenu(menuName = "Item")]
public class ItemData : ScriptableObject
{
    public ItemType ItemType;

    public ToolType toolType;

    public string itemName;
    public Sprite icon;

    public int maxStack = 64;
    public int maxStorage = 24;

    [TextArea]
    public string Description;

    public GameObject worldPrefab;
    public GameObject ghostPrefab;
    public GameObject inventoryPrefab;

    public int damage;
    public int range;

    public int foodRestore;
    public int waterRestore;
    public int healthRestore;
    public int breathRestore;
}