using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Waterbar waterData;
    public Foodbar foodData;
    public HealthBar healthData;
    public Breath breathData;
    public Death death;

    void Update()
    {
        waterData.currentWater = Mathf.Clamp(waterData.currentWater - .5f * Time.deltaTime, 0f, waterData.totalWater);
        foodData.currentFood = Mathf.Clamp(foodData.currentFood - .4f * Time.deltaTime, 0f, foodData.totalFood);

        if (waterData.currentWater <= 0)
        {
            healthData.currentHealth -= .5f * Time.deltaTime;
        }
        if (foodData.currentFood <= 0)
        {
            healthData.currentHealth -= .5f * Time.deltaTime;
        }
        if (breathData.currentBreath <= 0)
        {
            healthData.currentHealth -= .5f * Time.deltaTime;
        }
        if (waterData.currentWater >= 90 && foodData.currentFood >= 90)
        {
            healthData.currentHealth += .5f * Time.deltaTime;
        }

        healthData.currentHealth = Mathf.Clamp(healthData.currentHealth, 0f, healthData.maxHealth);

        if (healthData.currentHealth <= 0)
        {
            death.dead = true;
        }
    }

    public void UpdateWater(int water)
    {
        waterData.currentWater = Mathf.Clamp(waterData.currentWater + water, 0f, waterData.totalWater);
    }

    public void UpdateFood(int food)
    {
        foodData.currentFood = Mathf.Clamp(foodData.currentFood + food, 0f, foodData.totalFood);
    }
}
