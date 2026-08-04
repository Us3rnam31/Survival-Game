using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public Recipe selectedRecipe;

    public Image itemIcon;
    public TMP_Text itemName;
    public TMP_Text description;

    public Sprite blankIcon;

    public InventoryManager inventory;
    public RecipeDatabase recipeDatabase;
    public GameObject recipeButtonPrefab;
    public Transform recipeContent;
    public GameObject ingredientEntryPrefab;
    public Transform requirementPanel;
    public BackpackManager backpackManager;

    public bool hasBackpack = false;

    void Start()
    {
        PopulateRecipes();
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CraftSelectedRecipe();
            }
        }
    }

    public void SelectRecipe(Recipe recipe)
    {
        UpdateSelectedRecipe(recipe);
    }

    void CraftSelectedRecipe()
    {
        if (selectedRecipe == null)
        {
            return;
        }

        if (!CanCraft())
        {
            Debug.Log("Not enough resources");
            return;
        }

        foreach (Ingredient ingredient in selectedRecipe.ingredients)
        {
            inventory.RemoveItem(
                ingredient.item,
                ingredient.amount
            );
        }

        if (selectedRecipe.result.ItemType == ItemType.backpack)
        {
            inventory.AddInventorySlots(selectedRecipe.result.maxStorage);
            hasBackpack = true;
        }
        else
        {
            inventory.AddItem(
                selectedRecipe.result,
                selectedRecipe.resultAmount
            );
        }
        backpackManager.RefreshUI();

        Debug.Log(
            "Crafted " +
            selectedRecipe.result.itemName
        );
        UpdateSelectedRecipe(selectedRecipe);
    }

    void PopulateRecipes()
    {
        foreach (Recipe recipe in recipeDatabase.recipes)
        {
            GameObject button =
                Instantiate(recipeButtonPrefab, recipeContent);

            RecipeButton recipeButton =
                button.GetComponent<RecipeButton>();

            recipeButton.recipe = recipe;

            recipeButton.craftingManager = this;
        }
    }

    public void ClearSelectedRecipe()
    {
        selectedRecipe = null;

        itemIcon.sprite = blankIcon;
        itemName.text = "";
        description.text = "";

        foreach (Transform child in requirementPanel)
        {
            Destroy(child.gameObject);
        }
    }

    bool CanCraft()
    {
        foreach (Ingredient ingredient in selectedRecipe.ingredients)
        {
            if (inventory.GetItemCount(ingredient.item) < ingredient.amount)
            {
                return false;
            }
        }

        return true;
    }

    public void UpdateSelectedRecipe(Recipe recipe)
    {
        selectedRecipe = recipe;

        foreach (Transform child in requirementPanel)
        {
            Destroy(child.gameObject);
        }

        itemIcon.sprite = recipe.result.icon;
        itemName.text = recipe.result.itemName;
        description.text = recipe.result.Description;

        foreach (Ingredient ingredient in recipe.ingredients)
        {
            GameObject entry =
                Instantiate(
                    ingredientEntryPrefab,
                    requirementPanel
                );

            IngredientUI ui =
                entry.GetComponent<IngredientUI>();

            int owned =
                inventory.GetItemCount(
                    ingredient.item
                );

            ui.icon.sprite =
                ingredient.item.icon;

            ui.text.text =
                ingredient.item.itemName +
                " " +
                owned +
                "/" +
                ingredient.amount;
        }
    }
}
