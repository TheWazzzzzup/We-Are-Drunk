using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Will be incharge of assigening the ingredients into each area
/// </summary>
public class BarManager : MonoBehaviour
{
    // Publics
    public bool canMiniGame => CanMiniGame();

    // SerializeFields
    [Header("UI_Temp")]
    [SerializeField] TMP_Text currentDrinkText;
    
    [Header("Areas")]
    [SerializeField] IngredientSpawnArea alcholArea; 
    [SerializeField] IngredientSpawnArea juiceArea; 
    [SerializeField] IngredientSpawnArea cupArea; 
    [SerializeField] IngredientSpawnArea floatArea;
    [Space]

    [Header("Mini Games")]
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] MiniGameComponent iceGame;
    [SerializeField] MiniGameComponent floatGame;
    [SerializeField] MiniGameComponent craftGame;
    [Space]

    [SerializeField] Inventory inventory;

    [SerializeField] Ingredient baseIngredient;

    [SerializeField] CameraController cameraController;

    // Privates
    List<Ingredient> CurrentPickedIngredients = new();
    List<Ingredient> CurrentPickedIngredientsWithoutCup = new();

    List<Ingredient> currentAlchol = new();
    List<Ingredient> currentJuice = new();
    List<Ingredient> currentCup = new();
    List<Ingredient> currentFloat = new();

    CraftingManager craftManager => CraftingManager.Instance;

    // checks if the player completed any minigame, to block some interactions
    bool isMakingDrink = false;



    // Methods

    public void CheckForMinigamesCompletion()
    {
        if (isMakingDrink == false && iceGame.minigameState == MinigameState.Done || craftGame.minigameState == MinigameState.Done || floatGame.minigameState == MinigameState.Done)
        {
            isMakingDrink = true;
        }
        if ( iceGame.minigameState == MinigameState.Done && craftGame.minigameState == MinigameState.Done && floatGame.minigameState == MinigameState.Done)
        {
            Debug.Log("All Minigames Completed !!!!!!!!!!!!!!!!!!!!!");
        }
    }

    public void GetInventory()
    {
        UpdateIngredientList(inventory.Ingredients);
    }

    public void MinigameEnded(GameObject minigameSceneGameobject, MinigameType type)
    {
        switch (type)
        {
            case MinigameType.Float:

                break;
            case MinigameType.Ice:
                if (iceGame.minigameState != MinigameState.Done)
                {
                    cameraController.MoveToBar(2);
                    iceGame.MinigameToggleComplete();
                    IceTowerGameManager iceManager = minigameSceneGameobject.GetComponent<IceTowerGameManager>();
                    if (iceManager != null)
                    {
                        scoreManager.AddMinigameScore(iceManager.iceQualityScore);
                    }
                    else Debug.Log("Ice manager reference broken");
                }
                break;
            case MinigameType.Craft:
                if (craftGame.minigameState != MinigameState.Done)
                {
                    cameraController.MoveToBar(1);
                    craftGame.MinigameToggleComplete();
                    ShakerMinigameManager shakerManager = minigameSceneGameobject.GetComponent<ShakerMinigameManager>();
                    if (shakerManager != null)
                    {
                        scoreManager.AddMinigameScore(shakerManager.shakerQualityScore);
                    }
                    else Debug.Log("craft manager reference broken");
                }
                break;
     
        }

        CheckForMinigamesCompletion();
    }

        /// <summary>
        /// Updates the base ingredient based on the current tap
        /// </summary>
        /// <param name="ingredient"></param>
        public void UpdateBaseIngredient(Ingredient ingredient)
    {
        if (isMakingDrink) return;

        // TODO: create an indication that shows the player the picked ingredient
        if (ingredient == null)
        {
            baseIngredient = null;
            RefreshMinigamesStatus();
            return;
        }
        if (ingredient == baseIngredient)
        {
            baseIngredient = null;
            RefreshMinigamesStatus();
            return;
        }
        if (ingredient != null && ingredient != baseIngredient) {
            baseIngredient = ingredient;
            RefreshMinigamesStatus();
            return;
        }

    }

    void BaseIngredientVaildator(List<Ingredient> currentAlcholList)
    {
        if (currentAlcholList.Count < 0) {
            if (baseIngredient == null) return;
            if (baseIngredient != null) UpdateBaseIngredient(null);
        }
    }
    
    #region Minigames

    /// <summary>
    /// Checks if the player is able to enter minigame phase
    /// </summary>
    /// <returns>can the player enter minigame phase</returns>
    bool CanMiniGame()
    {
        if (CurrentPickedIngredientsWithoutCup.Count <= 0 || baseIngredient == null)
        {
            currentDrinkText.text = " Current Drink:";
            return false;
        }
        bool returnValue = craftManager.CompareToRecipe(CurrentPickedIngredientsWithoutCup, currentAlchol[0], out string name) && currentCup.Count > 0;
        currentDrinkText.text = " Current Drink: " + name;
        return returnValue;


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

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    }
