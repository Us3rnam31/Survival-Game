using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    public float range = 100f;
    float xRotation = 0f;
    GameObject lastLooked;
    public InventoryManager inventory;
    public InventorySlotUI inventory1;
    public bool mouseLock = true;
    public StatusManager statusManager;

    void Start()
    {

    }

    void Update()
    {
        if (mouseLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.collider.gameObject != lastLooked)
                {
                    lastLooked = hit.collider.gameObject;
                }

                if (lastLooked != null)
                {
                    ItemPickup pickup = lastLooked.GetComponent<ItemPickup>();
                    if (pickup != null && Input.GetMouseButtonDown(0))
                    {
                        ItemData item = lastLooked.GetComponent<ItemPickup>().itemData;
                        Debug.Log("Picking up " + pickup.itemData.itemName);
                        inventory.AddItem(pickup.itemData, 1);
                        Destroy(lastLooked);
                        lastLooked = null;
                    }
                }
            }
            else
            {
                lastLooked = null;
            }
            if(Physics.Raycast(ray, out hit, range))
            {
                if (hit.collider.gameObject.CompareTag("water") && Input.GetKeyDown(KeyCode.E))
                {
                    statusManager.UpdateWater(50);
                }
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log(Cursor.lockState);
        }
        
    }
}