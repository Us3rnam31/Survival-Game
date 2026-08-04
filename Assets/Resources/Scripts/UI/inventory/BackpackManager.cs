using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    public InventoryManager inventory;
    public Transform contentParent;
    public GameObject slotPrefab;

    void Update()
    {
        
    }

    public void RefreshUI()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 6; i < inventory.slots.Count; i++)
        {
            InventorySlot slot =
                inventory.slots[i];

            GameObject slotObject =
                Instantiate(
                    slotPrefab,
                    contentParent
                );

            InventorySlotUI ui =
                slotObject.GetComponent<InventorySlotUI>();

            if (slot.item != null)
            {
                ui.SetItem(
                    slot.item.icon,
                    slot.count
                );
            }
            else
            {
                ui.Clear();
            }
        }
    }

}