using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WorldObjectData")]
public class WorldObjectData : ScriptableObject
{
    public bool harvestable;
    public bool breakable;
    public int health;
    public List<ItemDrop> drops;
    public ToolType toolType;
}
