using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawnArea : MonoBehaviour
{
    // Public
    public IngredientType IngredientAreaType { get; private set; }



    // Serialized
    [SerializeField] Transform[] spawnPointsTransforms;

    [SerializeField] float numberOfIngredientsCanSpawn;

    // Private
    List<Ingredient> currentPickedIngredients;

    float maximumNumberOfIngredients;

    int index = 0;



    private void Awake()
    {
        // Checks if the number of ingredients allowed to spawn is at minimun
        if (numberOfIngredientsCanSpawn > 3) numberOfIngredientsCanSpawn = 3;

        // Sets the maximun number of ingredients avaialbe to pick
        maximumNumberOfIngredients = spawnPointsTransforms.Length;

        // Checks if there is an overlap between the maximun number of ingredients and the number of them that can spawn and cap that
        if (numberOfIngredientsCanSpawn > maximumNumberOfIngredients) numberOfIngredientsCanSpawn = maximumNumberOfIngredients;



    }

    // Should be called with the event
    /// <summary>
    /// This method fires off when the player presses on one of the ingredients
    /// </summary>
    /// <param name="pressedIngredient"></param>
    void IngredientPressedOverseer(Ingredient pressedIngredient)
    {
        // Validates the pressed ingredient type equlas to the area type
        if (pressedIngredient.Type == IngredientAreaType)
        {
            bool ingredientExsitsInTheList = false;
            // Checks if the ingredient is allready exists in the list of represented ingredients            
            foreach(var ingredient in currentPickedIngredients)
            {
                if (pressedIngredient == ingredient)
                {
                    ingredientExsitsInTheList = true;
                    currentPickedIngredients.Remove(ingredient);
                    index --;
                }
            }

            if (!ingredientExsitsInTheList && !IndexOverflow())
            {
                currentPickedIngredients.Add(pressedIngredient);
                index++;
            }
        }

    }

    bool IndexOverflow()
    {
        if (index == numberOfIngredientsCanSpawn)
        {
            Debug.Log($"Your {IngredientAreaType} area is filled with drinks / ingredients");
            return true;
        }
        else return false;
    }

}
