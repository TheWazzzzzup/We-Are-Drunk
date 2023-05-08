using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Recipe
{
    List<Ingredient> ingredients;

    public void CompareIngredients(Recipe newRecipe)
    {
        
        List<Ingredient> newIngredients = newRecipe.ingredients;
        int amountOfNewRecipeIngredients = newIngredients.Count;
        int amountOfIngredients = ingredients.Count;
        bool[,] correctIngredient;

        

        for(int i = 0; i < newIngredients.Count; i++)
        {
            for(int j = 0; j < ingredients.Count; j++)
            {
                
            }
        }
    }
}
