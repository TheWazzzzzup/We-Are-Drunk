using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager Instance;

    [SerializeField] Ingredient currentIngredient;
    [SerializeField] SpriteRenderer[] drinkParts;
    [SerializeField] Cup cup;

    public Ingredient CurrentIngredient { get { return currentIngredient; }}

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool CompareToRecipe(List<Ingredient> currentIngredients, Ingredient baseIngredient)
    {
        
        if (baseIngredient == null || currentIngredients == null)
        {
            Debug.Log($"one of {nameof(CompareToRecipe)} passed paramaters is null");
            return false;
        }

        int recipesMatch = 0;
        
        Ingredient[] ingredientsOnBar = currentIngredients.ToArray();

        RecipeDataSO[] recipesOfSameBase = RecipesHolder.Instance.ReturnBaseRecipeList(baseIngredient.Name);

        foreach (RecipeDataSO recipe in recipesOfSameBase)
        {
            if (CompareIngredientCollections(ingredientsOnBar, recipe.Ingredients)) recipesMatch++;
        }

        Debug.Log(recipesMatch);
        if (recipesMatch == 1) return true;
        else return false;

    }

    public void OnMouseDownIngredient(Ingredient ingredient)
    {
        if(CurrentIngredient == null || CurrentIngredient != ingredient)
        {
            currentIngredient = ingredient;
        }
    }

    public void UpdateCupVisuals()
    {
        for(int i = 0; i < drinkParts.Length; i++)
        {
            if(drinkParts[i].enabled)
            {
                continue;
            }

            drinkParts[i].enabled = true;
            drinkParts[i].color = currentIngredient.gameObject.GetComponent<SpriteRenderer>().color;
            break;
        }
    }
    
    public void ClearCup()
    {
        foreach(var p in drinkParts)
        {
            p.enabled = false;
        }
        cup.ClearIngredients();
    }

    public void ClearCurrentIngredient()
    {
        currentIngredient = null;
    }
   
    bool CompareIngredientCollections(IEnumerable<Ingredient> collectionFromInventory, IEnumerable<Ingredient> collection) {

        var recipe = collection.OrderByDescending(b => b.Name);
        var invent = collectionFromInventory.OrderByDescending(b => b.Name);

        return recipe.SequenceEqual(invent);
    
    }
}
