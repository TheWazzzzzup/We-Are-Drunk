using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Ingredient
{
    public string Name;
    public IngredientType type;
    public int amount;

    public Ingredient(string name,IngredientType type, int amount)
    {
        this.Name = name;
        this.type = type;
        this.amount = amount;
    }
}

public enum IngredientType
{
    Floats,
    Liquid,
    Juice
}
