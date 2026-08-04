using UnityEngine;
using UnityEngine.UI;

public class Foodbar : MonoBehaviour
{
    public Image Foodbaricon;

    public float currentFood = 100;
    public float totalFood = 100;

    void Update()
    {
        Foodbaricon.fillAmount = currentFood / totalFood;
        if (currentFood > totalFood)
        {
            currentFood -= (currentFood - totalFood);
        }

    }
    public void addFood(float food)
    {
        currentFood += food;
    }
    public void removeFood(float food)
    {
        currentFood -= food;
    }
}

