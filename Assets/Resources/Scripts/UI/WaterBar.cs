using UnityEngine;
using UnityEngine.UI;


public class Waterbar : MonoBehaviour
{
    public Image WaterBar;

    public float currentWater = 100;
    public float totalWater = 100;

    // Update is called once per frame
    void Update()
    {
        WaterBar.fillAmount = currentWater / totalWater;
        if(currentWater > totalWater)
        {
            currentWater -= (currentWater - totalWater);
        }
    }
    public void addWater(float water)
    {
        currentWater += water;
    }
    public void removeWater(float water)
    {
        currentWater -= water;
    }
}
