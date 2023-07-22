using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesHolder : MonoBehaviour
{

    public static RecipesHolder Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] public static int maxIngredientAmount = 4;


    [SerializeField]
    private RecipeDataSO[] _vodkaRecipes;
    [SerializeField]
    private RecipeDataSO[] _whiskeyRecipes;
    [SerializeField]
    private RecipeDataSO[] _whiteRumRecipes;

    public RecipeDataSO[] VodkaRecipes => _vodkaRecipes;
    public RecipeDataSO[] WhiskeyRecipes => _whiskeyRecipes;
    public RecipeDataSO[] WhiteRumRecipes => _whiteRumRecipes;

    public RecipeDataSO[] ReturnBaseRecipeList(IngredientName name)
    {
        switch(name)
        {

            case IngredientName.Vodka:
                return VodkaRecipes;

                break;
            case IngredientName.Whiskey:
                return WhiskeyRecipes;

                break;
            case IngredientName.WhiteRum:
                return WhiteRumRecipes;

                break;
            default:
                print("default recipe switch case... RUH ROH!");
                return null;
                break;
        }
    }

}
