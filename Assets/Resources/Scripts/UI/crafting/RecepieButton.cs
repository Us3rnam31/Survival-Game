using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeButton : MonoBehaviour
{
    public Recipe recipe;
    public CraftingManager craftingManager;

    void Start()
    {
        GetComponentInChildren<Image>().sprite = recipe.result.icon;
        GetComponentInChildren<TMP_Text>().text = recipe.result.itemName;
    }

    public void Clicked()
    {
        Debug.Log("clicked");
        craftingManager.SelectRecipe(recipe);
    }
}