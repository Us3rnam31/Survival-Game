using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Crafting/Recipe")]
public class Recipe : ScriptableObject
{
    public ItemData result;
    public int resultAmount = 1;

    public List<Ingredient> ingredients;
}