using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OldRecipeData", menuName = "ScriptableObjects/OldRecipe")]
public class OldRecipeDataSO : ScriptableObject
{
    [SerializeField] OldIngredient baseIngredient;
    [SerializeField] List<OldIngredient> Ingredients;
    bool discovered = false;

    public bool BaseMatch(OldIngredient other)
    {
        return baseIngredient.Matches(other);
    }

    //checks if the ingredients are a PERFECT match
    public bool IngredientsMatch(List<OldIngredient> otherIngredients)
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
