using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct OldIngredient
{
    public IngredientName name;
    public IngredientType type;
    public int amount;

    public OldIngredient(IngredientName name,IngredientType type, int amount)
    {
        this.name = name;
        this.type = type;
        this.amount = amount;
    }

    public bool Matches(OldIngredient other)
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

//public enum IngredientType
//{
//    Floats,
//    Alcohol,
//    Juice
//}

//public enum IngredientName
//{
//    //ALCOHOLS
//    Brandy,
//    Campari,
//    Gin,
//    Soju,
//    Tequila,
//    Tonic,
//    Vodka,
//    Whiskey,
//    WhiteRum,

//    //JUICES
//    Lemon,
//    Orange,
//    Cranberry,
//    Lime,
//    Cherry,

//    //FLOATS
//    Rosemary,
//    Cinnamon,
//    Maraschino_Cherries,
//    Mint_Leaves,
//    Nasturtium_Flowers
//}
