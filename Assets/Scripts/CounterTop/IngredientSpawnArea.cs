using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawnArea : MonoBehaviour
{
    // Public
    public IngredientType IngredientAreaType { get; private set; }

    // debug check
    public GameObject PrefabExample;

    // Serialized
    [SerializeField] Transform[] spawnPointsTransforms;

    [SerializeField] float numberOfIngredientsCanSpawn;

    // Private
    List<Ingredient> currentPickedIngredients;

    List<GameObject> spawnedIngredents;

    float maximumNumberOfIngredients;

    int index = 0;



    private void Awake()
    {
        IngredientAreaType = IngredientType.Alcohol;
        currentPickedIngredients = new List<Ingredient>();
        spawnedIngredents = new List<GameObject>();

        // Checks if the number of ingredients allowed to spawn is at minimun
        if (numberOfIngredientsCanSpawn > 3) numberOfIngredientsCanSpawn = 3;

        // Sets the maximun number of ingredients avaialbe to pick
        maximumNumberOfIngredients = spawnPointsTransforms.Length;

        // Checks if there is an overlap between the maximun number of ingredients and the number of them that can spawn and cap that
        if (numberOfIngredientsCanSpawn > maximumNumberOfIngredients) numberOfIngredientsCanSpawn = maximumNumberOfIngredients;

    }

    // Should be called with the event
    /// <summary>
    /// This method fires off when the player presses on one of the ingredients (Needs to be optimized!)
    /// </summary>
    /// <param name="pressedIngredient"></param>
    void IngredientPressed(Ingredient pressedIngredient)
    {
        // Validates the pressed ingredient type equlas to the area type
        if (pressedIngredient.Type == IngredientAreaType)
        {
            bool ingredientExsitsInTheList = false;
            // Checks if the ingredient is allready exists in the list of represented ingredients
            // ! * ! needs more tunning and i know it, super unpotimized and will be changed ! * !
            if (currentPickedIngredients.Count > 0)
            {
                foreach(var ingredient in currentPickedIngredients)
                {
                    if (pressedIngredient == ingredient)
                    {
                        foreach (var spawned in spawnedIngredents)
                        {
                            if (spawned.GetComponent<Ingredient>().Name == pressedIngredient.Name)
                            {
                                Destroy(spawned);
                            }
                        }
                        ingredientExsitsInTheList = true;
                        currentPickedIngredients.Remove(ingredient);
                        index --;
                        break;
                    }
                }
            }

            if (!ingredientExsitsInTheList && !IndexOverflow())
            {
                currentPickedIngredients.Add(pressedIngredient);
                spawnedIngredents.Add(Instantiate(PrefabExample, spawnPointsTransforms[index]));
                index++;
            }
        }

    }

    // dedbug pourpse only !s
    [ContextMenu("VodkaExample")]
    public void VodkaExample()
    {
        Ingredient ingre = PrefabExample.GetComponent<Ingredient>();

        IngredientPressed(ingre);
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
