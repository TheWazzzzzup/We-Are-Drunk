using UnityEngine;

public class SatisfactionScore
{

    public int SatisfactionScorePoints { get => CalculateSatisfactionScore(); }


    float qualityScore => qualityScoreClass.CurrentScore;
    int recipeCheckCounter;
    int recipeCheckPenalty;

    // Need to check how do i get this * Yarin Worked On it*
    int matchScore;

    QualityScore qualityScoreClass;

    public SatisfactionScore(QualityScore qualityScore, int penaltyValue)
    {
        qualityScoreClass = qualityScore;
        recipeCheckCounter = 0;
        if (penaltyValue < 0)
        {
            recipeCheckPenalty = 5;
        }
        else recipeCheckPenalty = penaltyValue;
    }

    public void ApplyMatchScore(int matchScore) {
        this.matchScore = matchScore;
    }

    /// <summary>
    /// This method should be called every time the player takes a peek in the recipe book
    /// </summary>
    public void AddCountToRecipeCheck() => recipeCheckCounter++;

    private int CalculateSatisfactionScore()
    {
        if (matchScore <= 0) {
            Debug.LogWarning($"The matchScore has not been passed");
            return 0;
        }
        return Mathf.RoundToInt((qualityScore * matchScore) - (recipeCheckPenalty * recipeCheckCounter));
    }

}
