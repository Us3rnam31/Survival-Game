using UnityEngine;

public class HotbarNavigation : MonoBehaviour
{
    public InventoryManager inventory;
    public Transform holdPoint;

    public int selectedSlot = 0;
    public int hotbarSize = 5;

    private GameObject heldObject;

    void Start()
    {
        UpdateHeldItem();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            selectedSlot = (selectedSlot + 1) % (hotbarSize + 1);
            UpdateHeldItem();
        }
        else if (scroll < 0f)
        {
            selectedSlot = (selectedSlot - 1 + hotbarSize + 1) % (hotbarSize + 1);
            UpdateHeldItem();
        }

        // Number keys 0-5 select hotbar slots
        for (int i = 0; i <= hotbarSize; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                selectedSlot = i;
                UpdateHeldItem();
                break;
            }
        }
    }

    public void UpdateHeldItem()
    {
        if (heldObject != null)
        {
            Destroy(heldObject);
            heldObject = null;
        }

        if (selectedSlot == 0)
            return;

        int inventoryIndex = selectedSlot - 1;
        if (inventoryIndex >= inventory.slots.Count)
            return;

        InventorySlot slot = inventory.slots[inventoryIndex];

        if (slot.item == null)
            return;

        heldObject = Instantiate(slot.item.inventoryPrefab, holdPoint);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        Collider col = heldObject.GetComponent<Collider>();
        if (col != null) col.enabled = false;
    }
}
