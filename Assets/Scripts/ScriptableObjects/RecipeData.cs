using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "ScriptableObjects/Recipe")]
public class RecipeData : ScriptableObject
{
    Ingredient baseIngredient;
    [SerializeField] List<Ingredient> Ingredients;
    bool discovered = false;

    public bool IngredientsMatch(List<Ingredient> ingredients)
    {
        foreach(var i in ingredients)
        {
            //TODO compare name of each ingredient, if name matches compare amount
        }
        return false;
    }
}
