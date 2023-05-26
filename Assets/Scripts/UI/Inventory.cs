using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Ingredient> ingredients = new List<Ingredient>();
    [SerializeField] private int maxIngredientAmount = 4;

    public List<Ingredient> Ingredients { get { return ingredients; } }

    public void AddIngredient(Ingredient ingredient)
    {
        if (maxIngredientAmount <= ingredients.Count)
        {
            Debug.Log("Can't add more ingredients");
            return;
        }
        ingredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if(ingredients.Count == 0)
        {
            Debug.LogError($"Trying to remove {ingredient} from empty inventroy");
        }
        ingredients.Remove(ingredient);
    }

    public bool ContainsIngredient(Ingredient ingredient)
    {
        return ingredients.Contains(ingredient);
    }

    public void Clear()
    {
        ingredients.Clear();
    }
}
