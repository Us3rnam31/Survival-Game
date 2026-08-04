using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    public InventorySlotUI[] slotUIs;

    public int slotCount = 5;

    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            slots.Add(new InventorySlot());
        }

        UpdateUI();
    }

    public bool AddItem(ItemData newItem, int amount)
    {
        Debug.Log("Adding " + newItem.itemName);
        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].IsEmpty() && slots[i].item == newItem && slots[i].count < newItem.maxStack)
            {
                int space = newItem.maxStack - slots[i].count;

                int toAdd = Mathf.Min(space, amount);

                slots[i].count += toAdd;

                amount -= toAdd;

                if (amount <= 0)
                {
                    UpdateUI();

                    return true;
                }
            }
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsEmpty())
            {
                slots[i].item = newItem;

                slots[i].count = Mathf.Min(amount, newItem.maxStack);

                amount -= slots[i].count;

                if (amount <= 0)
                {
                    UpdateUI();

                    return true;
                }
            }
        }

        UpdateUI();

        return amount <= 0;
    }

    public void DropItem(int slotIndex, Vector3 dropPosition)
    {
        InventorySlot slot = slots[slotIndex];

        if (slot.IsEmpty())
        {
            return;
        }

        Instantiate(slot.item.worldPrefab, dropPosition, Quaternion.identity);

        slot.count--;

        if (slot.count <= 0)
        {
            slot.item = null;

            slot.count = 0;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("slotUIs length = " + slotUIs.Length);
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item != null)
            {
                UnityEngine.Debug.Log("Slot " + i + ": " + slots[i].item.itemName + " x" + slots[i].count);
                Debug.Log("UI updating slot " + i + " with count " + slots[i].count);
            }
        }
        for (int i = 0; i < slotUIs.Length; i++)
        {
            if (i >= slots.Count)
            {
                continue;
            }

            if (slots[i].item != null)
            {
                slotUIs[i].SetItem(slots[i].item.icon, slots[i].count);
            }
            else
            {
                slotUIs[i].Clear();
            }
        }
    }
    public int GetItemCount(ItemData item)
    {
        int total = 0;

        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item)
            {
                total += slot.count;
            }
        }

        return total;
    }
    public void RemoveItem(ItemData item, int amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item)
            {
                int removeAmount = Mathf.Min(slot.count, amount);

                slot.count -= removeAmount;
                amount -= removeAmount;

                if (slot.count <= 0)
                {
                    slot.item = null;
                    slot.count = 0;
                }

                if (amount <= 0)
                {
                    break;
                }
            }
        }

        UpdateUI();
    }

    public void AddInventorySlots(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            slots.Add(new InventorySlot());
        }

        UpdateUI();
    }
}