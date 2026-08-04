using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public WorldObjectData data;

    public int currentHealth;

    void Start()
    {
        currentHealth = data.health;
    }
}