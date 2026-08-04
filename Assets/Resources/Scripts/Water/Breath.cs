using UnityEngine;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public Image Bubble;
    public PlayerMovement playerMovement;
    public GameObject player;
    public GameObject water;

    public float currentBreath = 100f;
    public float totalBreath = 100f;

    void Update()
    {
        Bubble.fillAmount = currentBreath / totalBreath;

        if (player.transform.position.y < water.transform.position.y)
        {
            Bubble.enabled = true;
            currentBreath = Mathf.Clamp(currentBreath - 5f * Time.deltaTime, 0f, totalBreath);
        }
        else
        {
            Bubble.enabled = false;
            currentBreath = totalBreath;
        }
    }
}
