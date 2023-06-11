using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CostumerData : ScriptableObject
{
    [SerializeField] RecipeDataSO recipe;
    [SerializeField] string[] hints, positiveFeedbackLinse, nutrealFeedbackLines, negetiveFeedbackLines;



    [SerializeField] string greetingLine;

    public RecipeDataSO Recipe { get => recipe; }
    public string GreetingLine { get => greetingLine; }
    public string[] PositiveFeedbackLinse { get => positiveFeedbackLinse; }
    public string[] NutrealFeedbackLines { get => nutrealFeedbackLines; }
    public string[] NegetiveFeedbackLines { get => negetiveFeedbackLines; }


    public string GetLine(LineType type)
    {
        string[] lines;
        switch (type)
        {
            case LineType.Hint:
                lines = hints;
                break;
            case LineType.PositiveFeedback:
                lines = positiveFeedbackLinse;
                break;
            case LineType.NeutralFeedback:
                lines = nutrealFeedbackLines;
                break;
            case LineType.NegativeFeedback:
                lines = negetiveFeedbackLines;
                break;
            default:
                Debug.LogError("Unsupported line type!");
                return null;
        }
        if (lines.Length <= 0)
        {
            Debug.LogError("No " + type.ToString() + " lines were added to the costumer data");
            return null;
        }

        //choose a line at random
        return lines[Random.Range(0, lines.Length)];
    }

    public enum LineType
    {
        Hint,
        PositiveFeedback,
        NeutralFeedback,
        NegativeFeedback
    }

}
