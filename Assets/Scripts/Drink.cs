using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    [SerializeField] Ingredient currentIngredient;
    [SerializeField] float maxAmount = 100;
    [SerializeField] float currentAmount = 0;


    //adds an ingredient to the list, if the ingredient exists it just adds the amount to the already existing ingredient
    public void AddIngredient(Ingredient newIngredient)
    {
        bool inList = false;
        Ingredient existingIngredient;
        //checks if the ingredient is in the list already
        if(ingredients.Count > 0)
        {
            for(int i = 0; i < ingredients.Count; i++)
            {
                //if it is then it adds to its amount
                if (ingredients[i].name == newIngredient.name)
                {
                    Ingredient combinedAmountIng = new Ingredient(newIngredient.name, newIngredient.type, ingredients[i].amount + newIngredient.amount);

                    ingredients[i] = combinedAmountIng;
                }
            }
        }
        else
        {
            ingredients.Add(newIngredient);
        }
        
    }

}
