using UnityEngine;

public class crafting : MonoBehaviour
{
    public KeyCode actionKey = KeyCode.C;
    public GameObject Gameobject;
    public PlayerCamera playerCamera;
    public CraftingManager craftingManager;
    public CommandConsoleToggle commandConsoleToggle;
    public BackpackToggle BackpackToggle;
    public bool HudToggle = false;

    void Start()
    {
        Gameobject.SetActive(false);
    }
    void Update()
    {
        bool backpackOpen = BackpackToggle != null && BackpackToggle.HudToggle;
        bool consoleOpen = commandConsoleToggle != null && commandConsoleToggle.HudToggle;

        if (Input.GetKeyDown(actionKey) && !HudToggle && !backpackOpen && !consoleOpen)
        {
            openCraftingHud();
            HudToggle = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(actionKey)) && HudToggle)
        {
            closeCraftingHud();
            HudToggle = false;
        }
    }

    void openCraftingHud()
    {
        Gameobject.SetActive(true);
        playerCamera.mouseLock = false;
    }
    void closeCraftingHud()
    {
        Gameobject.SetActive(false);
        playerCamera.mouseLock = true;
        craftingManager.ClearSelectedRecipe();
    }
}
