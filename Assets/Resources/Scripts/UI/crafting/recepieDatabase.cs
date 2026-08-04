using UnityEngine;

[CreateAssetMenu(menuName = "Crafting/Recipe Database")]
public class RecipeDatabase : ScriptableObject
{
    public Recipe[] recipes;
}