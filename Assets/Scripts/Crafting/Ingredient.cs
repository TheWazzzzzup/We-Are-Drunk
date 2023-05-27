using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private IngredientName iName;
    [SerializeField] private IngredientType iType;
    [SerializeField] private Inventory inventory;
    [SerializeField] private bool isSelected = false;

    public UnityEvent<Ingredient, bool> OnIngredientSelected = new UnityEvent<Ingredient, bool>();

    public IngredientName Name { get { return iName; } }
    public IngredientType Type { get { return iType; } }

    public bool IsSelected { get => isSelected; set => SetSelected(value); }

    private void SetSelected(bool value)
    {
        isSelected = value;
        OnIngredientSelected.Invoke(this, value);
    }

    public void Start()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
            return;
        }
    }

    public override bool Equals(object other)
    {
        if (other is not Ingredient)
        {
            return false;
        }

        Ingredient otherIngredient = (Ingredient)other;

        return otherIngredient.Name == this.iName && otherIngredient.Type == this.iType;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventory == null)
        {
            Debug.LogError("No inventory found");
            return;
        }

        if (IsSelected)
        {
            IsSelected = false;
            inventory.RemoveIngredient(this);
        }
        else
        {
            IsSelected = true;
            inventory.AddIngredient(this);
        }

        Debug.Log($" {iType} Selected : {isSelected}");
    }
}

public enum IngredientType
{
    Floats,
    Alcohol,
    Juice,
    Cup,

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