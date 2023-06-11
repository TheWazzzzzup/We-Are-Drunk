using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CostumerManager : MonoBehaviour
{
    [SerializeField] GameObject costumerPrefab;
    [SerializeField] Transform spawnPoint, standingPoint;

    CostumerController currentCostumer;

    [Button]
    public CostumerController SpawnCostumer(CostumerData data)
    {
        if (currentCostumer != null)
        {
            Debug.LogError("Can only have one active costumer at a time");
            return null;
        }

        //create the costumer
        CostumerController costumer = CreateCostumer(data);

        //set the current costumer
        currentCostumer = costumer;

        //move the costumer to the standing point
        costumer.MoveTo(standingPoint.position).onComplete += () => OnCostumerReachedStandingPoint(costumer);
        //show the greeting line
        costumer.ShowDialogue(costumer.CostumerData.GreetingLine);

        return costumer;
    }

    [Button]
    public void RemoveCurrentCostumer()
    {
        //if we don't have a costumer, throw an error
        if (currentCostumer == null)
        {
            Debug.LogError("Trying to remove a costumer while there are none");
            return;
        }

        //Move the costumer to spawn point and destroy it
        currentCostumer.MoveTo(spawnPoint.position).onComplete += () => Destroy(currentCostumer.gameObject);
    }

    [Button]
    public int GetMatchScoreWithCostumerFeedback(RecipeDataSO recipe)
    {
        int score = GetMatchScore(recipe);

        switch (score)
        {
            case 100:
                {
                    currentCostumer.ShowDialogue(currentCostumer.CostumerData.GetLine(CostumerData.LineType.PositiveFeedback));
                    break;
                }
            case 70:
                {
                    currentCostumer.ShowDialogue(currentCostumer.CostumerData.GetLine(CostumerData.LineType.NeutralFeedback));
                    break;
                }
            default:
                currentCostumer.ShowDialogue(currentCostumer.CostumerData.GetLine(CostumerData.LineType.NegativeFeedback));
                break;
        }

        return score;
    }


    private int GetMatchScore(RecipeDataSO recipe)
    {
        return MatchScore.Calculate(currentCostumer.CostumerData.Recipe, recipe);
    }


    private CostumerController CreateCostumer(CostumerData data)
    {
        //create and set game object
        GameObject costumer = Instantiate(costumerPrefab, spawnPoint.position, Quaternion.identity);
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
}

public enum FeedbackType
{
    Positive,
    Netrual,
    Negetive
}