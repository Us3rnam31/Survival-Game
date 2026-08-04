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

    // Update is called once per frame
    void Update()
    {
        Bubble.fillAmount = currentBreath / totalBreath;
        if (player.transform.position.y < water.transform.position.y)
        {
            Bubble.enabled = true;
            currentBreath -= 5f * Time.deltaTime;
        }
        else
        {
            Bubble.enabled = false;
            currentBreath = 100f;
        }
    }
}
