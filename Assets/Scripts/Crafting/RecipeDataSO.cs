using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "ScriptableObjects/Recipe")]
public class RecipeDataSO : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] Ingredient[] ingredients = new Ingredient[4];

    public Ingredient[] Ingredients { get { return ingredients; } }
}
