using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A class that represents an inventory of ingredients
public class Inventory : MonoBehaviour
{
    // A list of ingredients contained in the inventory
    [SerializeField] private List<Ingredient> ingredients = new List<Ingredient>();

    // A dictionary holding the maximum allowed amount of each ingredient type
    private Dictionary<IngredientType, int> maxIngredientAmounts = new Dictionary<IngredientType, int>()
    {
        {IngredientType.Alcohol , 4},
        {IngredientType.Juice , 4 },
        {IngredientType.Floats , 1 },
        {IngredientType.Cup , 1 }
    };

    // A read-only property that returns the list of ingredients
    public List<Ingredient> Ingredients { get { return ingredients; } }

    // A method that adds a new ingredient to the inventory
    public void AddIngredient(Ingredient ingredient)
    {
        // Check if the ingredient type is defined in the dictionary
        if (!maxIngredientAmounts.ContainsKey(ingredient.Type))
        {
            Debug.Log($"Max amount not defined for {ingredient.Type}");
            return;
        }

        // Check if adding another ingredient of the same type surpasses the allowed maximum
        if (maxIngredientAmounts[ingredient.Type] <= ingredients.FindAll(i => i.Type == ingredient.Type).Count)
        {
            Debug.Log($"Can't add more {ingredient.Type} ingredients");
            return;
        }

        // Add the new ingredient
        ingredients.Add(ingredient);
    }

    // A method that removes an ingredient from the inventory
    public void RemoveIngredient(Ingredient ingredient)
    {
        // Check if the inventory is empty
        if (ingredients.Count == 0)
        {
            Debug.LogError($"Trying to remove {ingredient} from empty inventory");
        }
        // Remove the ingredient
        ingredients.Remove(ingredient);
    }

    // A method that checks if a given ingredient is currently inside the inventory
    public bool ContainsIngredient(Ingredient ingredient) => ingredients.Contains(ingredient);

    // A method that clears the inventory, removing all ingredients from it
    public void Clear() => ingredients.Clear();
}
