using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int numberOfMinigames;
    [SerializeField] int penaltyValue;


    QualityScore qualityScore;
    SatisfactionScore satisfactionScore;

    private void Start() {
        qualityScore = new (numberOfMinigames);
        satisfactionScore = new(qualityScore, penaltyValue);
    }

    public void AddMinigameScore(int score) { 
        qualityScore.AddScore(score);
    }

    public float GetCurrntQualityScore() {
        return qualityScore.CurrentScore;
    }

    public void FillMatchScore(int matchScore) { 
        satisfactionScore.ApplyMatchScore(matchScore);
    }

    public int GetSatisfactionScore() {
        return satisfactionScore.SatisfactionScorePoints;
    }
}
