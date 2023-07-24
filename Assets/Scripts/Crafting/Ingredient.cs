using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool interactable = true;
    [SerializeField] private IngredientName iName;
    [SerializeField] private IngredientType iType;
    [SerializeField] private Inventory inventory;
    [SerializeField] private bool isSelected = false;

    public UnityEvent<Ingredient, bool> OnIngredientSelected = new UnityEvent<Ingredient, bool>();

    public UnityEvent<bool> OnSelected = new UnityEvent<bool>();

    public IngredientName Name { get { return iName; } }
    public IngredientType Type { get { return iType; } }

    public bool IsSelected { get => isSelected; set => SetSelected(value); }


    public void Start()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }

        SetSelected(false);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Type.GetHashCode();
    }

    public override bool Equals(object other)
    {
        if (other is null)
        {
            return false;
        }
        
        if (other is not Ingredient)
        {
            return false;
        }


        Ingredient otherIngredient = (Ingredient)other;

        return otherIngredient.Name == this.iName && otherIngredient.Type == this.iType;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!interactable)
        {
            return;
        }

        if (inventory == null)
        {
            Debug.LogError("No inventory found");
            return;
        }

        if (IsSelected)
        {
            IsSelected = false;
            inventory.RemoveIngredient(this);
            return;
        }

        if (!inventory.CanAdd(this))
        {
            Debug.Log($"can't add {Name} to inventory");
            return;
        }

        IsSelected = true;
        inventory.AddIngredient(this);

    }
    private void SetSelected(bool value)
    {
        isSelected = value;
        OnIngredientSelected.Invoke(this, value);
        OnSelected.Invoke(value);
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
    Vodka,
    WhiteRum,
    Whiskey,

    //JUICES
    Lemon,
    Orange,
    Cranberry,
    Honey,
    Vermouth,

    //FLOATS
    Cherry,
    Cinnamon,
    Mint,
    DragonloomFlower,
    Sugar_Cubes,
    Jalapenos,
    Sage,

    Cup,

    NOTHING
}