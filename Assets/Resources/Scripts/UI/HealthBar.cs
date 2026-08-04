using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    public float currentHealth = 100;
    public float maxHealth = 100;

    void Update()
    {
        fillImage.fillAmount = currentHealth / maxHealth;    
    }

    public void damage(float damage)
    {
        currentHealth -= damage;
    }
}