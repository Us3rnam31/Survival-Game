using UnityEngine;


public class Death : MonoBehaviour
{
    public HealthBar healthData;
    public PlayerCamera playerCamera;
    public GameObject deathScreen;
    public bool dead = false;

    void Start()
    {
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
