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

    public Sprite GetSpawnedIngredientSprite()
    {
        return spawnedIngredientsInArea[0].GetComponent<SpriteRenderer>().sprite;
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