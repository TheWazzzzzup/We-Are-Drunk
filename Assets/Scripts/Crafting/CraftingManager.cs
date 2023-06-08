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
        Ingredient[] currentCupIngredients = currentIngredients.ToArray();

        RecipeDataSO[] recipesOfSameBase = RecipesHolder.Instance.ReturnBaseRecipeList(baseIngredient.Name);

        bool[] matchingIngredients;

        foreach (RecipeDataSO recipe in recipesOfSameBase)
        {
            print("checking recipe " + recipe.name);
            //reset bool array to false at the start of each recipe being checked
            matchingIngredients = new bool[RecipesHolder.maxIngredientAmount - 1];

            //compare all ingredients in each recipe
            //for each ingredient in cup
            for (int i = 1; i < currentCupIngredients.Length; i++)
            {

                //go over each ingredient in recipe
                for (int j = 1; j < recipe.Ingredients.Length; j++)
                {

                    //if ingredient in array already matched, check next ingredient
                    if (matchingIngredients[j - 1])
                    {
                        continue;
                    }

                    if (currentCupIngredients?[i] == null && recipe.Ingredients?[j] == null)
                    {
                        matchingIngredients[j - 1] = true;
                        break;
                    }
                    else if (currentCupIngredients?[i] == null)
                    {
                        continue;
                    }
                    else if (recipe.Ingredients[j] == null)
                    {
                        continue;
                    }

                    //else check if ingredient matches
                    if (currentCupIngredients[i].Name == recipe.Ingredients[j].Name)
                    {
                        matchingIngredients[j - 1] = true;
                        break;
                    }

                }
                bool isAllfalse = matchingIngredients.All(b => !b);
                if (isAllfalse)
                {
                    break;
                }
            }

            //if bool array == true, recipe match, return true!
            bool isAllTrue = matchingIngredients.All(b => b);
            if (isAllTrue)
            {
                print("cup matches recipe " + recipe.name);
                return true;
            }
        }
        //else check next recipe
        //if completed all recipes then return false
        print("no matching recipe");
        return false;
    }

    [ContextMenu("Compare to recipes")] // Old maybe can be delted in the future 
    bool CompareToRecipe()
    {
        print("comparing cup to recipes");
        //determine base of the current drink
        Ingredient baseIngredient = cup.baseIngredient;

        Ingredient[] currentCupIngredients = cup.GetIngredients();

        //find the recipe array specific to that base
        RecipeDataSO[] recipesOfSameBase = RecipesHolder.Instance.ReturnBaseRecipeList(baseIngredient.Name);

        //bool array that holds if the ingredient was already matched (for situations with 2+ of the same ingredients)
        //including nulls!! ^^^^
        bool[] matchingIngredients;

        //for each recipe compare cups ingredients
        foreach(RecipeDataSO recipe in recipesOfSameBase)
        {
            print("checking recipe " + recipe.name);
            //reset bool array to false at the start of each recipe being checked
            matchingIngredients = new bool[RecipesHolder.maxIngredientAmount - 1];
            
            //compare all ingredients in each recipe
            //for each ingredient in cup
            for (int i = 1; i < currentCupIngredients.Length; i++)
            {

                //go over each ingredient in recipe
                for (int j = 1; j < recipe.Ingredients.Length; j++)
                {

                    //if ingredient in array already matched, check next ingredient
                    if (matchingIngredients[j - 1])
                    {
                        continue;
                    }
                    
                    if(currentCupIngredients?[i] == null && recipe.Ingredients?[j] == null)
                    {
                        matchingIngredients[j - 1] = true;
                        break;
                    }
                    else if(currentCupIngredients?[i] == null)
                    {
                        continue;
                    }
                    else if(recipe.Ingredients[j] == null)
                    {
                        continue;
                    }

                    //else check if ingredient matches
                    if (currentCupIngredients[i].Name == recipe.Ingredients[j].Name)
                    {
                        matchingIngredients[j - 1] = true;
                        break;
                    }

                }
                bool isAllfalse = matchingIngredients.All(b => !b);
                if (isAllfalse)
                {
                    break;
                }
            }

            //if bool array == true, recipe match, return true!
            bool isAllTrue = matchingIngredients.All(b => b);
            if(isAllTrue)
            {
                print("cup matches recipe " + recipe.name);
                return true;
            }
            //else check next recipe
            //if completed all recipes then return false

        }


        print("no matching recipe");
        return false;

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

    [ContextMenu("Empty Cup")]
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
}
