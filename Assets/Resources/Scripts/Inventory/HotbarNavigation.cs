using UnityEngine;

public class HotbarNavigation : MonoBehaviour
{
    public InventoryManager inventory;
    public Transform holdPoint;

    public int selectedSlot = 0;

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
            selectedSlot++;

            if (selectedSlot > 5)
            {
                selectedSlot = 0;
            }

            UpdateHeldItem();
        }

        if (scroll < 0f)
        {
            selectedSlot--;

            if (selectedSlot < 0)
            {
                selectedSlot = 5;
            }

            UpdateHeldItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectedSlot = 0;
            UpdateHeldItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSlot = 1;
            UpdateHeldItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlot = 2;
            UpdateHeldItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlot = 3;
            UpdateHeldItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlot = 4;
            UpdateHeldItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlot = 5;
            UpdateHeldItem();
        }
    }

    public void UpdateHeldItem()
    {
        if (heldObject != null)
        {
            Destroy(heldObject);
        }

        if (selectedSlot == 0)
        {
            return;
        }

        InventorySlot slot = inventory.slots[selectedSlot - 1];

        if (slot.item == null)
        {
            return;
        }

        heldObject = Instantiate(
            slot.item.inventoryPrefab,
            holdPoint
        );

        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Collider col = heldObject.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }

        Debug.Log(heldObject);
    }
}