using UnityEngine;
using TMPro;

public class CommandConsoleToggle : MonoBehaviour
{
    public KeyCode actionKey = KeyCode.F1;
    public GameObject Gameobject;
    public PlayerCamera playerCamera;
    public CraftingManager craftingManager;
    public PlayerMovement playerMovement;
    public TMP_InputField inputField;
    public bool HudToggle = false;

    void Start()
    {
        Gameobject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(actionKey) && !HudToggle)
        {
            Gameobject.SetActive(true);
            playerCamera.mouseLock = false;
            playerMovement.movement = false;
            inputField.ActivateInputField();
            inputField.Select();
            HudToggle = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(actionKey)) && HudToggle)
        {
            Gameobject.SetActive(false);
            playerCamera.mouseLock = true;
            playerMovement.movement = true;
            HudToggle = false;
        }
    }
}