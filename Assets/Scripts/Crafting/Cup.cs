using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cup : MonoBehaviour
{
    
    [SerializeField] public Ingredient baseIngredient { get; private set; }
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] bool isFull = false;

    private void Awake()
    {
        ingredients = new Ingredient[RecipesHolder.maxIngredientAmount];
    }

    private void OnMouseUp()
    {
        if (isFull)
        {
            return;
        }

        if(CraftingManager.Instance.CurrentIngredient == null)
        {
            print("no ingredient selected");
            return;
        }

        if (ingredients[0] == null && CraftingManager.Instance.CurrentIngredient.Type != IngredientType.Alcohol)
        {
            print("base must be alcohol");
            return;
        }

        for(int i = 0; i < ingredients.Length; i++)
        {

            if(ingredients[i] != null)
            {
                continue;
            }

            ingredients[i] = CraftingManager.Instance.CurrentIngredient;

            if(i == 0)
            {
                baseIngredient = ingredients[i];
            }

            break;
        }

        CraftingManager.Instance.UpdateCupVisuals();
        CraftingManager.Instance.ClearCurrentIngredient();

        if (CheckIfFull())
        {
            isFull = true;
        }

        if(isFull)
        {
            //TODO compare recipe method
        }

    }


    public bool CheckIfFull()
    {
        for(int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void ClearIngredients()
    {
        ingredients = new Ingredient[RecipesHolder.maxIngredientAmount];
        isFull = false;
    }

    public Ingredient[] GetIngredients()
    {
        return ingredients;
    }
}
