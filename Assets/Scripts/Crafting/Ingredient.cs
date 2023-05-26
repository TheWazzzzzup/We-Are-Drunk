using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour ,IPointerClickHandler
{
    [SerializeField] private IngredientName iName;
    [SerializeField] private IngredientType iType;
    [SerializeField] private Inventory inventory;
    [SerializeField] private bool isSelected = false;

    public UnityEvent<Ingredient, bool> OnIngredientSelected = new UnityEvent<Ingredient, bool>();

    public IngredientName Name { get { return iName; } }
    public IngredientType Type { get { return iType; } }

    public void Start()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
            return;
        }
    }

    private void OnMouseDown()
    {

    }

    private void Unselect()
    {
        isSelected = false;
        OnIngredientSelected.Invoke(this, isSelected);
        Debug.Log($"Unselected {iType}");
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
        if (isSelected)
        {
            Unselect();
            return;
        }
        if (inventory == null)
        {
            Debug.LogError("No inventory found");
            return;
        }

        inventory.AddIngredient(this);
        isSelected = true;
        OnIngredientSelected.Invoke(this, isSelected);

        Debug.Log($"Selected {iType}");
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