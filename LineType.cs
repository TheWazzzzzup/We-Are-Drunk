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
