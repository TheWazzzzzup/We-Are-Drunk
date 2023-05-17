using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Ingredient
{
    public IngredientName name;
    public IngredientType type;
    public int amount;

    public Ingredient(IngredientName name,IngredientType type, int amount)
    {
        this.name = name;
        this.type = type;
        this.amount = amount;
    }

    public bool Matches(Ingredient other)
    {
        if(other.name == name && other.amount == amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public enum IngredientType
{
    Floats,
    Alcohol,
    Juice
}

public enum IngredientName
{
    //ALCOHOLS
    Whiskey,
    Tequila,
    Gin,
    Vodka,
    Brandy,
    White_Rum,
    Campari,
    Soju,
    Tonic,

    //JUICES
    Lemon,
    Orange,
    Cranberry,
    Lime,
    Cherry,

    //FLOATS
    Rosemary,
    Cinnamon,
    Maraschino_Cherries,
    Mint_Leaves,
    Nasturtium_Flowers
}
