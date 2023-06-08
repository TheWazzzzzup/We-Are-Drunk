using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainIngredient : MonoBehaviour
{
    [SerializeField] Ingredient ingredientIdentity;
    
    [SerializeField] IngredientGameEvent gameEvent;

    private void OnMouseDown()
    {
        gameEvent.Raise(ingredientIdentity);
    }
}
