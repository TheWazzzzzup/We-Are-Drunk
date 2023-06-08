using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CostumerData : ScriptableObject
{
    [SerializeField] RecipeDataSO recipe;
    [SerializeField] string[] hints;

    [SerializeField, Tooltip("Lines that the costumer should say in respond to when they are served a drink." +
        "Lines higher on the list indicate more negetive reaction, while those lower on the list indicate more positive reaction")]
    string[] FeedbackLines;

    [SerializeField] string greetingLine;

    public RecipeDataSO Recipe { get => recipe; }
    public string GreetingLine { get => greetingLine; }

    public string GetHint()
    {
        if (hints.Length <= 0)
        {
            Debug.LogError("No hints were added to the costumer data");
            return null;
        }

        //choose an hint at random
        return hints[Random.Range(0, hints.Length)];
    }
}
