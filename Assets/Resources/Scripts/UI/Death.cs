using UnityEngine;

public class Death : MonoBehaviour
{
    public HealthBar healthData;
    public PlayerCamera playerCamera;
    public GameObject deathScreen;
    public bool dead = false;

    bool wasDead = false;

    void Start()
    {
        deathScreen.SetActive(false);
    }

    void Update()
    {
        // Only change mouseLock when the death state actually changes,
        // not every frame — otherwise it fights with menus that unlock the mouse.
        if (dead == wasDead) return;
        wasDead = dead;

        if (dead)
        {
            deathScreen.SetActive(true);
            playerCamera.mouseLock = false;
        }
        else
        {
            deathScreen.SetActive(false);
            playerCamera.mouseLock = true;
        }
    }
}
