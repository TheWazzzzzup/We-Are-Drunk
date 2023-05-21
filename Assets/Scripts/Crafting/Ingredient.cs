using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private IngredientName iName;
    [SerializeField] private IngredientType iType;

    public IngredientName Name { get { return iName; } }
    public IngredientType Type { get { return iType; } }

    private void OnMouseDown()
    {
        CraftingManager.Instance.OnMouseDownIngredient(this);
    }

    public override bool Equals(object other)
    {
        if(other is not Ingredient)
        {
            return false;
        }

        Ingredient otherIngredient = (Ingredient)other;

        return otherIngredient.Name == this.iName && otherIngredient.Type == this.iType;
    }
}

public enum IngredientType
{
    Floats,
    Alcohol,
    Juice,

    NOTHING
}

public enum IngredientName
{
    //ALCOHOLS
    Brandy,
    Campari,
    Gin,
    Soju,
    Tequila,
    Tonic,
    Vodka,
    Whiskey,
    WhiteRum,

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
    Nasturtium_Flowers,

    NOTHING
}