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
    private RecipeDataSO[] _brandyRecipes;
    [SerializeField]
    private RecipeDataSO[] _campariRecipes;
    [SerializeField]
    private RecipeDataSO[] _ginRecipes;
    [SerializeField]
    private RecipeDataSO[] _sojuRecipes;
    [SerializeField]
    private RecipeDataSO[] _vodkaRecipes;
    [SerializeField]
    private RecipeDataSO[] _tequilaRecipes;
    [SerializeField]
    private RecipeDataSO[] _tonicRecipes;
    [SerializeField]
    private RecipeDataSO[] _whiskeyRecipes;
    [SerializeField]
    private RecipeDataSO[] _whiteRumRecipes;

    public RecipeDataSO[] BrandyRecipes => _brandyRecipes;
    public RecipeDataSO[] CampariRecipes => _campariRecipes;
    public RecipeDataSO[] GinRecipes => _ginRecipes;
    public RecipeDataSO[] SojuRecipes => _sojuRecipes;
    public RecipeDataSO[] VodkaRecipes => _vodkaRecipes;
    public RecipeDataSO[] TequilaRecipes => _tequilaRecipes;
    public RecipeDataSO[] TonicRecipes => _tonicRecipes;
    public RecipeDataSO[] WhiskeyRecipes => _whiskeyRecipes;
    public RecipeDataSO[] WhiteRumRecipes => _whiteRumRecipes;

    public RecipeDataSO[] ReturnBaseRecipeList(IngredientName name)
    {
        switch(name)
        {
            case IngredientName.Brandy:
                return BrandyRecipes;
                break;
            case IngredientName.Campari:
                return CampariRecipes;
                break;
            case IngredientName.Gin:
                return GinRecipes;

                break;
            case IngredientName.Soju:
                return SojuRecipes;

                break;
            case IngredientName.Vodka:
                return VodkaRecipes;

                break;
            case IngredientName.Tequila:
                return TequilaRecipes;

                break;
            case IngredientName.Tonic:
                return TonicRecipes;

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
