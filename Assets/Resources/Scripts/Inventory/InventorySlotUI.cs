using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public InventorySlot slot;

    public Image slotImage;

    public TMP_Text countText;

    void Awake()
    {
        if (slotImage == null)
        {
            slotImage = GetComponent<Image>();
        }
    }

    public void SetItem(Sprite icon, int count)
    {
        Debug.Log("Sprite received: " + icon);
        Debug.Log("Updating UI count to: " + count);

        slotImage.sprite = icon;
        slotImage.enabled = true;

        if (count > 0)
        {
            countText.text = count.ToString();
        }
        else
        {
            countText.text = "";
        }
    }

    public void Clear()
    {
        slotImage.sprite = null;

        slotImage.enabled = false;

        countText.text = "";
    }
}