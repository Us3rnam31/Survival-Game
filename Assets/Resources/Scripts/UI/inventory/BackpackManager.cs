using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    public InventoryManager inventory;
    public Transform contentParent;
    public GameObject slotPrefab;

    // Slots at indices 0..(hotbarSlotCount-1) are the hotbar; backpack slots start after.
    public int hotbarSlotCount = 5;

    public void RefreshUI()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = hotbarSlotCount; i < inventory.slots.Count; i++)
        {
            InventorySlot slot = inventory.slots[i];

            GameObject slotObject = Instantiate(slotPrefab, contentParent);

            InventorySlotUI ui = slotObject.GetComponent<InventorySlotUI>();

            if (slot.item != null)
                ui.SetItem(slot.item.icon, slot.count);
            else
                ui.Clear();
        }
    }
}
