using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CostumerManager : MonoBehaviour
{
    [SerializeField] GameObject _costumerPrefab;
    [SerializeField] Transform _spawnPoint, _standingPoint;
    /// <summary>
    /// The list of all the costumers in the game
    /// </summary>
    [SerializeField] List<CostumerData> _costumersRegistry;

    // Temporey * * * * * * ** * * * * * *
    public Color purple;
    public Color redWithHit;
    public Color golden;
    public Color deepBrown;

    // * * ** * * * end temp
    
    CostumerController _currentCostumer;

    /// <summary>
    /// Spawn a costumer with the given data
    /// </summary>
    /// <param name="data">The data of the costumer to spawn</param>
    /// <returns>Costumer Controller of the spawned costumer</returns>
    [Button]
    public CostumerController SpawnCostumer(CostumerData data)
    {
        if (_currentCostumer != null)
        {
            Debug.LogError("Can only have one active costumer at a time");
            return null;
        }

        //create the costumer
        CostumerController costumer = CreateCostumer(data);

        //set the current costumer
        _currentCostumer = costumer;

        //move the costumer to the standing point
        costumer.MoveTo(_standingPoint.position).onComplete += () => OnCostumerReachedStandingPoint(costumer);
        //show the greeting line
        costumer.ShowDialogue(costumer.CostumerData.GreetingLine);

        return costumer;
    }

    /// <summary>
    /// Spawn a random costumer from the registry
    /// </summary>
    /// <returns>Costumer Controller of the spawned costumer</returns>
    public CostumerController SpawnCostumer()
    {
        //is the registry empty?
        if (_costumersRegistry.Count == 0)
        {
            Debug.LogError("Cannot spawn a costumer. Costumer Registry is empty. Please populate the list with costumer data from the inspector.");
            return null;
        }

        //Choose a random costumer data
        CostumerData data = _costumersRegistry[Random.Range(0, _costumersRegistry.Count)];
        //Spawn the costumer
        CustomerLoop(data);
        return SpawnCostumer(data);
    }

    [Button]
    public void RemoveCurrentCostumer()
    {
        //if we don't have a costumer, throw an error
        if (_currentCostumer == null)
        {
            Debug.LogError("Trying to remove a costumer while there are none");
            return;
        }

        //Move the costumer to spawn point and destroy it
        _currentCostumer.MoveTo(_spawnPoint.position).onComplete += () => Destroy(_currentCostumer.gameObject);
    }

    [Button]
    public int GetMatchScoreWithCostumerFeedback(RecipeDataSO recipe)
    {
        int score = GetMatchScore(recipe);

        switch (score)
        {
            case 100:
                {
                    _currentCostumer.ShowDialogue(_currentCostumer.CostumerData.GetLine(CostumerData.LineType.PositiveFeedback));
                    break;
                }
            case 70:
                {
                    _currentCostumer.ShowDialogue(_currentCostumer.CostumerData.GetLine(CostumerData.LineType.NeutralFeedback));
                    break;
                }
            default:
                _currentCostumer.ShowDialogue(_currentCostumer.CostumerData.GetLine(CostumerData.LineType.NegativeFeedback));
                break;
        }

        return score;
    }


    private int GetMatchScore(RecipeDataSO recipe)
    {
        return MatchScore.Calculate(_currentCostumer.CostumerData.Recipe, recipe);
    }


    private CostumerController CreateCostumer(CostumerData data)
    {
        //create and set game object
        GameObject costumer = Instantiate(_costumerPrefab, _spawnPoint.position, Quaternion.identity);
        costumer.transform.SetParent(transform);

        //initialize the controller
        var controller = costumer.GetComponent<CostumerController>();
        controller.CostumerData = data;
        return controller;
    }



    private void OnCostumerReachedStandingPoint(CostumerController costumer)
    {
        //say an hint
        string hint = costumer.CostumerData.GetLine(CostumerData.LineType.Hint);
        costumer.ShowDialogue(hint);
    }

    // Remove after playtest? 
#if true
    void CustomerLoop(CostumerData data)
    {
        if (data.name.Contains("Cosmopolitian")) _costumerPrefab.GetComponent<SpriteRenderer>().color = redWithHit;

        if (data.name.Contains("Flity")) _costumerPrefab.GetComponent<SpriteRenderer>().color = Color.red;

        if (data.name.Contains("Old")) _costumerPrefab.GetComponent<SpriteRenderer>().color = deepBrown;

        if (data.name.Contains("Rum")) _costumerPrefab.GetComponent<SpriteRenderer>().color = Color.red;

        if (data.name.Contains("Zestfire")) _costumerPrefab.GetComponent<SpriteRenderer>().color = golden;

        if (data.name.Contains("Zombie")) _costumerPrefab.GetComponent<SpriteRenderer>().color = purple;
    }


#endif
}

public enum FeedbackType
{
    Positive,
    Netrual,
    Negetive
}