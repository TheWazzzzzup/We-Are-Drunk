using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// Will be incharge of assigening the ingredients into each area
/// </summary>
public class BarManager : MonoBehaviour
{
    // Publics

    // SerializeFields
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

    [SerializeField] Ingredient? baseIngredient;

    // Privates
    List<Ingredient> CurrentPickedIngredients = new();
    List<Ingredient> CurrentPickedIngredientsWithoutCup = new();

    List<Ingredient> currentAlchol = new();
    List<Ingredient> currentJuice = new();
    List<Ingredient> currentCup = new();
    List<Ingredient> currentFloat = new();

    CraftingManager craftManager => CraftingManager.Instance;
    bool canMiniGame => CanMiniGame();

    // Methods

    public void GetInventory()
    {
        UpdateIngredientList(inventory.Ingredients);
    }
    
    /// <summary>
    /// Updates the base ingredient based on the current tap
    /// </summary>
    /// <param name="ingredient"></param>
    public void UpdateBaseIngredient(Ingredient ingredient)
    {
        // TODO: create an indication that shows the player the picked ingredient

        if (ingredient == null) {
            Debug.Log("Picked Non valid Ingredient, Check if you assigend the ingredient");
            return;
        }

        if (ingredient.Type != IngredientType.Alcohol) {
            Debug.Log("Main ingredient cannot be no alcholic");
            return;
        }

        if (baseIngredient == null){
            baseIngredient = ingredient;
            RefreshMinigamesStatus();
            return;
        }

        if (ingredient.Name == baseIngredient.Name)
        {
            baseIngredient = null;
            RefreshMinigamesStatus();
            return;
        }

        baseIngredient = ingredient;
        RefreshMinigamesStatus();
    }

    void BaseIngredientVaildator(List<Ingredient> currentAlcholList)
    {
        if (currentAlcholList.Count < 1) {
            UpdateBaseIngredient(baseIngredient);
            return;
        }

        foreach (var alcholic in currentAlcholList)
        {
            if (baseIngredient == null) return;
            if (alcholic.Name == baseIngredient.Name)
            {
                UpdateBaseIngredient(null);
                return;
            }
        }

        UpdateBaseIngredient(baseIngredient);
        return;
    }
    
    #region Minigames

    /// <summary>
    /// Checks if the player is able to enter minigame phase
    /// </summary>
    /// <returns>can the player enter minigame phase</returns>
    bool CanMiniGame()
    {
        if (CurrentPickedIngredientsWithoutCup.Count <= 0 || baseIngredient == null) return false;
        return craftManager.CompareToRecipe(CurrentPickedIngredientsWithoutCup, currentAlchol[0]) && currentCup.Count > 0;

        //if (currentCup.Count > 0 && currentAlchol.Count > 0 && currentFloat.Count > 0 && currentJuice.Count > 0) return true;
        //else return false;
    }

    void RefreshMinigamesStatus()
    {
        bool canMinigame = CanMiniGame();
        iceGame.SetMinigameActivision(canMinigame);
        floatGame.SetMinigameActivision(canMinigame);
        craftGame.SetMinigameActivision(canMinigame);
    }

    #endregion
    

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
        AssginIngredientToArea();
        RefreshMinigamesStatus();

    }

    /// <summary>
    /// Will assigen the ingredients to each area
    /// </summary>
    private void AssginIngredientToArea()
    {
        AreaListGenerator();

        alcholArea.SpawnAreaUpdate(currentAlchol);
        juiceArea.SpawnAreaUpdate(currentJuice);
        floatArea.SpawnAreaUpdate(currentFloat);
        cupArea.SpawnAreaUpdate(currentCup);

        // baseIngredientChecker
        BaseIngredientVaildator(currentAlchol);

        // Addes releavent lists to recepie compare 
        CurrentPickedIngredientsWithoutCup.AddRange(currentAlchol);
        CurrentPickedIngredientsWithoutCup.AddRange(currentFloat);
        CurrentPickedIngredientsWithoutCup.AddRange(currentJuice);
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
        CurrentPickedIngredientsWithoutCup.Clear();


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