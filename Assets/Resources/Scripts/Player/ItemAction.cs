using UnityEngine;

public class ItemAction : MonoBehaviour
{
    public InventoryManager inventory;
    public Camera playerCamera;
    public HotbarNavigation hotbar;

    // Update is called once per frame
    void Update()
    {
        if (hotbar.selectedSlot == 0)
            return;

        if (hotbar.selectedSlot - 1 >= inventory.slots.Count)
            return;

        if (Input.GetMouseButtonDown(0) &&
            inventory.slots[hotbar.selectedSlot - 1].item != null)
        {
            Debug.Log("Clicked");
            UseHeldItem();
        }
    }

    void UseHeldItem()
    {
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        RaycastHit hit;


        ItemData item = inventory.slots[hotbar.selectedSlot - 1].item;

        if (!Physics.Raycast(ray, out hit, item.range))
        {
            return;
        }
        Debug.Log("Hit " + hit.collider.name);

        switch (item.ItemType)
        {
            case ItemType.Tool:
                UseTool(item, hit);
                break;
        }
    }

    void UseTool(ItemData item, RaycastHit hit)
    {
        Debug.Log("Hit: " + hit.collider.name);

        WorldObject worldObject = hit.collider.GetComponent<WorldObject>();

        if (worldObject == null)
        {
            Debug.Log("no world object");
            return;
        }

        if (!worldObject.data.harvestable)
        {
            Debug.Log("not harvestable");
            return;
        }

        if (item.toolType != worldObject.data.toolType)
        {
            Debug.Log("incorrect tool");
            return;
        }

        worldObject.currentHealth -= item.damage;

        Debug.Log("Health: " + worldObject.currentHealth);

        if (worldObject.currentHealth <= 0)
        {
            Debug.Log("Deadified");
            foreach (ItemDrop drop in worldObject.data.drops)
            {
                inventory.AddItem(drop.item, drop.amount);
            }

            Destroy(worldObject.transform.parent.gameObject);
        }
    }
}
