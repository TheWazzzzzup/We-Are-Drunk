using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "ScriptableObjects/Recipe")]
public class RecipeDataSO : ScriptableObject
{
    [SerializeField] Ingredient baseIngredient;
    [SerializeField] List<Ingredient> addedIngredients;


    public bool BaseMatch(Ingredient other)
    {
        return baseIngredient.Matches(other);
    }

    //checks if the ingredients are a PERFECT match
    public bool IngredientsMatch(List<Ingredient> otherIngredients)
    {
        if(otherIngredients.Count != addedIngredients.Count)
            return false;

        bool[] ingredientExists = new bool[addedIngredients.Count];

        for(int i = 0; i < addedIngredients.Count; i++)
        {
            for(int j = 0; j < otherIngredients.Count; j++)
            {
                if(addedIngredients[i].Matches(otherIngredients[j]))
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

    
}
