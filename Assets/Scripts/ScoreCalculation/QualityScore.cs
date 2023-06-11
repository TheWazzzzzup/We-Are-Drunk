using System;
using UnityEngine;

public class QualityScore
{
    public float CurrentScore { get => CalculateScore(); private set { } }

    int[] minigamesScores;
    int index;

    int maxNumberOfMinigames;


    public QualityScore(int numberOfMinigames)
    {
        minigamesScores = new int[numberOfMinigames];
        maxNumberOfMinigames = numberOfMinigames;
        CurrentScore = 0;
        index = 0;
    }

    /// <summary>
    /// In charge of clearing the class
    /// </summary>
    /// <param name="numberOfMinigames"></param>
    public void RestartScore(int numberOfMinigames)
    {
        Array.Clear(minigamesScores, 0, numberOfMinigames);
        CurrentScore = 0;
        index = 0;
    }

    /// <summary>
    /// Addes score to array of qulity scores
    /// </summary>
    /// <param name="score">The score a player acheived for a minigame</param>
    public void AddScore(int score)
    {
        if (index + 1 >= maxNumberOfMinigames) Debug.LogWarning($"You excedded the number of minigames you have set for this {nameof(QualityScore)} class");
        minigamesScores[index] = score;
        index++;
    }

    /// <summary>
    /// Returns the qulity score based on the minigames scores added
    /// </summary>
    /// <returns>The currenct calculated quality score of the player (0 means no data/bugs)</returns>
    private float CalculateScore()
    {
        if (index == 0) return 0;
        if (index >= maxNumberOfMinigames)
        {
            Debug.LogWarning($"{nameof(QualityScore)} index is toped of, you added to much scores");
            return 0;
        }

        int score = 0;
        for (int i = 0; i < minigamesScores.Length; i++)
        {
            score += minigamesScores[i];
        }

        return ((score / minigamesScores.Length) / 100);
    }
}
