using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Will be incharge of assigening the ingredients into each area
/// </summary>
public class BarManager : MonoBehaviour
{
    // Public


    // SerializeField
    [SerializeField] IngredientSpawnArea alcholArea; 
    [SerializeField] IngredientSpawnArea juiceArea; 
    [SerializeField] IngredientSpawnArea cupArea; 
    [SerializeField] IngredientSpawnArea floatArea; 

    // Private
    List<Ingredient> CurrentPickedIngredients;


    List<Ingredient> currentAlchol = new();
    List<Ingredient> currentJuice = new();
    List<Ingredient> currentCup = new();
    List<Ingredient> currentFloat = new();

    private void Awake()
    {
        CurrentPickedIngredients = new();
    }


    /// <summary>
    /// Updates the list of ingredients, should be called everytime the player exits the inventory
    /// </summary>
    /// <param name="sentIngredientsList"></param>
    public void UpdateIngredientList(List<Ingredient> sentIngredientsList)
    {
        if (sentIngredientsList == null)
        {
            Debug.LogWarning($"The ingredients list is null in {this.name} , {nameof(UpdateIngredientList)}");
            return;
        }

        CurrentPickedIngredients = sentIngredientsList;
        AssigenIngredientToArea();

    }


    /// <summary>
    /// Will assigen the ingredients to each area
    /// </summary>
    private void AssigenIngredientToArea()
    {
        AreaListGenerator();

        alcholArea.SpawnAreaUpdate(currentAlchol);
        juiceArea.SpawnAreaUpdate(currentJuice);
        floatArea.SpawnAreaUpdate(currentFloat);
        cupArea.SpawnAreaUpdate(currentCup);
    }


    /// <summary>
    /// incharge of generating lists based on the type of the ingredients
    /// </summary>
    private void AreaListGenerator()
    {
        foreach (var ingredient in CurrentPickedIngredients)
        {
            switch (ingredient.Type)
            {
                case IngredientType.Floats:
                    currentFloat.Add(ingredient);
                    break;
                case IngredientType.Alcohol:
                    currentAlchol.Add(ingredient);
                    break;
                case IngredientType.Juice:
                    currentJuice.Add(ingredient);
                    break;
                case IngredientType.Cup:
                    currentCup.Add(ingredient);
                    break;
                case IngredientType.NOTHING:
                    break;
            }
        }
    }

}