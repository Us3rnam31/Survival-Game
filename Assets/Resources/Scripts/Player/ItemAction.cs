using UnityEngine;

public class ItemAction : MonoBehaviour
{
    public InventoryManager inventory;
    public Camera playerCamera;
    public HotbarNavigation hotbar;
    public PlayerCamera playerCameraScript;

    void Update()
    {
        // Don't act while a menu is open
        if (playerCameraScript != null && !playerCameraScript.mouseLock)
            return;

        if (hotbar.selectedSlot == 0)
            return;

        int inventoryIndex = hotbar.selectedSlot - 1;
        if (inventoryIndex >= inventory.slots.Count)
            return;

        if (Input.GetMouseButtonDown(0) && inventory.slots[inventoryIndex].item != null)
            UseHeldItem(inventoryIndex);
    }

    void UseHeldItem(int inventoryIndex)
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        ItemData item = inventory.slots[inventoryIndex].item;

        if (!Physics.Raycast(ray, out hit, item.range))
            return;

        switch (item.ItemType)
        {
            case ItemType.Tool:
                UseTool(item, hit);
                break;
        }
    }

    void UseTool(ItemData item, RaycastHit hit)
    {
        WorldObject worldObject = hit.collider.GetComponent<WorldObject>();

        if (worldObject == null || !worldObject.data.harvestable)
            return;

        if (item.toolType != worldObject.data.toolType)
            return;

        worldObject.currentHealth -= item.damage;

        if (worldObject.currentHealth <= 0)
        {
            foreach (ItemDrop drop in worldObject.data.drops)
                inventory.AddItem(drop.item, drop.amount);

            Destroy(worldObject.transform.parent.gameObject);
        }
    }
}
