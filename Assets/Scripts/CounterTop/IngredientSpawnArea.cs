using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class IngredientSpawnArea : MonoBehaviour
{
    // Public


    /// Serialzie
    [SerializeField] IngredientType type;
    [Space]

    [SerializeField] Transform[] spawnPointsTransforms;

    [SerializeField] List<GameObject> spawnedIngredientsInArea;
    [SerializeField] List<GameObject> ingredientsOfTypePrefabs;

    // Private
    int spawnTranformsIndex = 0;

    List<IngredientName> areaIngredientsName = new();

    /// <summary>
    /// Called when ever there is a spawn area update
    /// </summary>
    /// <param name="areaList"></param>
    public void SpawnAreaUpdate(List<Ingredient> areaList)
    {
        ClearSpawnedObjects();

        #region Debug   
        // Check if area list is big enough (> 0)
        if (areaList.Count <= 0)
        {
            Debug.Log($"An empty {type.ToString()} list was inserted");
            return;
        }

        // double check script and inserted types
        if (areaList[0].Type != this.type)
        {
            Debug.Log("The list inserted by code and the type of the area is not type match");
            return;
        }
        #endregion

        // checks for a match between the ingredient name and the prefab
        foreach (var ingredient in areaList)
        {
            foreach (var prefab in ingredientsOfTypePrefabs)
            {
                if (prefab.GetComponent<Ingredient>().Name == ingredient.Name)
                {
                    spawnedIngredientsInArea.Add(Instantiate(prefab, spawnPointsTransforms[spawnTranformsIndex]));
                    spawnTranformsIndex++;
                    break;
                }
            }
        }
    }




    /// <summary>
    /// Clear The Spawned Ingredients
    /// </summary>
    private void ClearSpawnedObjects()
    {
        foreach (var gameObject in spawnedIngredientsInArea)
        {
            Destroy(gameObject);
        }
        spawnedIngredientsInArea.Clear();
        areaIngredientsName.Clear();
        spawnTranformsIndex = 0;
    }
}

#region OldCodeToRefer
//// Public
//public IngredientType IngredientAreaType { get; private set; }

//// debug check
//public GameObject PrefabExample;

//// Serialized
//[SerializeField] Transform[] spawnPointsTransforms;

//[SerializeField] int numberOfIngredientsCanSpawn;

//// Private
//List<Ingredient> currentPickedIngredients;

//public List<GameObject> spawnedIngredents;

//int maximumNumberOfIngredients;

//int index = 0;

//private void Awake()
//{
//    IngredientAreaType = IngredientType.Alcohol;
//    currentPickedIngredients = new List<Ingredient>();
//    spawnedIngredents = new List<GameObject>();

//    // Checks if the number of ingredients allowed to spawn is at minimun
//    if (numberOfIngredientsCanSpawn > 3) numberOfIngredientsCanSpawn = 3;

//    // Sets the maximun number of ingredients avaialbe to pick
//    maximumNumberOfIngredients = spawnPointsTransforms.Length;

//    // Checks if there is an overlap between the maximun number of ingredients and the number of them that can spawn and cap that
//    if (numberOfIngredientsCanSpawn > maximumNumberOfIngredients) numberOfIngredientsCanSpawn = maximumNumberOfIngredients;

//}

//// Should be called with the event
///// <summary>
///// This method fires off when the player presses on one of the ingredients (Needs to be optimized!)
///// </summary>
///// <param name="pressedIngredient"></param>
//void IngredientPressed(Ingredient pressedIngredient)
//{
//    // Validates the pressed ingredient type equlas to the area type
//    if (pressedIngredient.Type == IngredientAreaType)
//    {
//        bool ingredientExsitsInTheList = false;
//        // Checks if the ingredient is allready exists in the list of represented ingredients
//        // ! * ! needs more tunning and i know it, super unpotimized and will be changed (redundent currenctPick and spawnedIngredients)! * !
//        if (currentPickedIngredients.Count > 0)
//        {
//            foreach(var ingredient in currentPickedIngredients)
//            {
//                if (pressedIngredient == ingredient)
//                {
//                    foreach (var spawned in spawnedIngredents)
//                    {
//                        if (spawned.GetComponent<Ingredient>().Name == pressedIngredient.Name)
//                        {
//                            Destroy(spawned);
//                            spawnedIngredents.Remove(spawned);
//                            break;
//                        }
//                    }
//                    ingredientExsitsInTheList = true;
//                    currentPickedIngredients.Remove(ingredient);
//                    index --;
//                    break;
//                }
//            }
//        }

//        if (!ingredientExsitsInTheList && !IndexOverflow())
//        {
//            currentPickedIngredients.Add(pressedIngredient);
//            spawnedIngredents.Add(Instantiate(PrefabExample, spawnPointsTransforms[index]));
//            index++;
//        }
//    }

//}

//// dedbug pourpse only !s
//[ContextMenu("VodkaExample")]
//public void VodkaExample()
//{
//    Ingredient ingre = PrefabExample.GetComponent<Ingredient>();

//    IngredientPressed(ingre);
//}

//bool IndexOverflow()
//{
//    if (index == numberOfIngredientsCanSpawn)
//    {
//        Debug.Log($"Your {IngredientAreaType} area is filled with drinks / ingredients");
//        return true;
//    }
//    else return false;
//}
#endregion