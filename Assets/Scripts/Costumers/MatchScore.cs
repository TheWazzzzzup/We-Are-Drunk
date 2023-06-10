using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MatchScore
{
    public static int Calculate(RecipeDataSO costumerPrefrence, RecipeDataSO incomingRecipie)
    {
        if (costumerPrefrence == null || incomingRecipie == null)
        {
            return 0;
        }


        //this is a perfect match
        if (costumerPrefrence == incomingRecipie)
        {
            return 100;
        }

        //only the base ingredient match
        if (costumerPrefrence.Ingredients[0] == incomingRecipie.Ingredients[0])
        {
            return 70;
        }

        //there is no match
        return 50;
    }
}
