using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableIngredient : MonoBehaviour
{
    [SerializeField] Ingredient Ingredient = new Ingredient(IngredientName.Vodka, IngredientType.Alcohol, 100);


    private void OnMouseDown()
    {
        
    }
}
