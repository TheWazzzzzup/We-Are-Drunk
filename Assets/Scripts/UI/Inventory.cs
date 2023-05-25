using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Ingredient> ingredients = new List<Ingredient>();

    public List<Ingredient> Ingredients { get { return ingredients; } }

    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
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
