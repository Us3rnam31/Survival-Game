using UnityEngine;

public class BackpackToggle : MonoBehaviour
{
    public PlayerCamera playerCamera;
    public BackpackManager backpackManager;
    public CraftingManager craftingManager;
    public CommandConsoleToggle commandConsoleToggle;
    public GameObject Backpack;
    public crafting crafting;
    public KeyCode actionKey = KeyCode.E;
    public bool HudToggle = false;

    void Start()
    {
        closeBackpack();
    }

    void Update()
    {
        if (Input.GetKeyDown(actionKey) && !HudToggle && craftingManager.hasBackpack && !crafting.HudToggle && !commandConsoleToggle.HudToggle)
        {
            openBackpack();
            HudToggle = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(actionKey)) && HudToggle)
        {
            closeBackpack();
            HudToggle = false;
        }
    }


    void openBackpack()
    {
        Backpack.SetActive(true);
        playerCamera.mouseLock = false;
        backpackManager.RefreshUI();
    }
    void closeBackpack()
    {
        Backpack.SetActive(false);
        playerCamera.mouseLock = true;
    }
}
