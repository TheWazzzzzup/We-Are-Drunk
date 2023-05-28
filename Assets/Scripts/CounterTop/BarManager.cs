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
    [Header("Areas")]
    [SerializeField] IngredientSpawnArea alcholArea; 
    [SerializeField] IngredientSpawnArea juiceArea; 
    [SerializeField] IngredientSpawnArea cupArea; 
    [SerializeField] IngredientSpawnArea floatArea;
    [Space]

    [Header("Mini Games")]
    [SerializeField] MiniGameComponent iceGame;
    [SerializeField] MiniGameComponent floatGame;
    [SerializeField] MiniGameComponent craftGame;
    [Space]

    [SerializeField] Inventory inventory;

    // Private
    List<Ingredient> CurrentPickedIngredients = new();

    List<Ingredient> currentAlchol = new();
    List<Ingredient> currentJuice = new();
    List<Ingredient> currentCup = new();
    List<Ingredient> currentFloat = new();

    bool canMiniGame => CanMinigame();


    public void GetInventory()
    {
        UpdateIngredientList(inventory.Ingredients);
        RefreshMinigamesStatus();
    }


    // should be private // DebugNote!
    [ContextMenu("Refresh")]
    public void RefreshMinigamesStatus()
    {
        iceGame.SetMinigameActivision(canMiniGame);
        floatGame.SetMinigameActivision(canMiniGame);
        craftGame.SetMinigameActivision(canMiniGame);
    }

    /// <summary>
    /// Checks if the player is able to enter minigame phase
    /// </summary>
    /// <returns>can the player enter minigame phase</returns>
    bool CanMinigame()
    {
        if (currentCup.Count > 0 && currentCup.Count > 0 && currentFloat.Count > 0 && currentJuice.Count > 0) return true;
        else return false;
    }


    #region Ingredient List Related
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
        RefreshMinigamesStatus();

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
    /// incharge of generating lists based on the type of the ingredients after clearing the old list
    /// </summary>
    private void AreaListGenerator()
    {
        // Clear all current list
        currentFloat.Clear();
        currentAlchol.Clear();
        currentJuice.Clear();
        currentCup.Clear();


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
                    Debug.Log("Nothing is called?!?");
                    break;
            }
        }
    }
    #endregion

}