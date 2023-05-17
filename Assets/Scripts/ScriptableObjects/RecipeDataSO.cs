using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "ScriptableObjects/Recipe")]
public class RecipeDataSO : ScriptableObject
{
    [SerializeField] Ingredient baseIngredient;
    [SerializeField] List<Ingredient> Ingredients;
    bool discovered = false;

    public bool BaseMatch(Ingredient other)
    {
        return baseIngredient.Matches(other);
    }

    //checks if the ingredients are a PERFECT match
    public bool IngredientsMatch(List<Ingredient> otherIngredients)
    {
        if(otherIngredients.Count != Ingredients.Count)
            return false;

        bool[] ingredientExists = new bool[Ingredients.Count];

        for(int i = 0; i < Ingredients.Count; i++)
        {
            for(int j = 0; j < otherIngredients.Count; j++)
            {
                if(Ingredients[i].Matches(otherIngredients[j]))
                {
                    ingredientExists[i] = true;
                    break;
                }
            }
        }

        foreach(var b in ingredientExists)
        {
            if (!b)
            {
                return false;
            }
        }

        return true;
    }

    public void Discovered()
    {
        discovered = true;
    }
}
