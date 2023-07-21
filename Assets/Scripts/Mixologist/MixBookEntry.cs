using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MixBookEntry : MonoBehaviour
{

    [SerializeField] Image recipeImage;
    [SerializeField] TMP_Text recipeName;
    [SerializeField] TMP_Text recipeIngredients;

    [Button("AssigenToUIElement")]
    public void AssigenToUIElement(MixSO mixSO)
    {
        recipeImage.sprite = mixSO.drinkSprite;
        recipeName.text = mixSO.name;
        string ingredientsText = "";
        foreach (var ingredient in mixSO.recipe.Ingredients)
        {
            ingredientsText += $"{ingredient.Name}\n";
        }
        recipeIngredients.text = ingredientsText;

    }

}
