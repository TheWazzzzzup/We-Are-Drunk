using UnityEngine;

public class ShakerMinigameManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] CheckShakerMinigameCollisions shakerCollision; 
    [SerializeField] ShakerMinigameStatusBar shakerStatusBar;

    [Header("Score")]
    [SerializeField] int littleScoreInc; // The small score Incremental to the bar related location
    [SerializeField] int bigScoreInc; // The bigger score Incremental to the bar related location
    [SerializeField] float scoreMultiplier; // The score multiplier to the bar related location, called in fixed update

    [Header("Target")]
    [SerializeField] float goalTimeOnTarget = 5f; // The goal time the player needs to reach when on target
    [SerializeField] int onTargetOffset; // The location offset the player is allowed in order to stay on target

    /// <summary>
    /// Wheter or not the player is currntly on target
    /// </summary>
    bool onTarget;
    
    // Related Location
    float trasnlatedBarRelatedLocation = 0;
    float linerTarget; // the liner represantion of the score related location
    int shakerMaxLimit = 100;

    // Timer
    float totalTime; // updated time the player has on target

    // Disposable (Memory Saver / Preoptimization)
    int rndRange;

    private void Start()
    {
        CreateRandomDesignatedArea();
        shakerStatusBar.ChangeRandomTimeOnTarget(goalTimeOnTarget);
        totalTime = goalTimeOnTarget;
    }

    private void FixedUpdate()
    {
        UpdateBarRelatedLocation(shakerCollision.Location);

        if (onTarget)
        {
            totalTime -= Time.fixedDeltaTime; // reduce the time by using the delta time incrementals
            if (totalTime <= 0f)
            {
                // TODO add game ended logic

                totalTime = 0;
            }
            shakerStatusBar.ChangeRandomTimeOnTarget(totalTime);
        }
    }

    /// <summary>
    /// Updates the logic that is driven by the shaker location
    /// </summary>
    /// <param name="currentLoc"></param>
    void UpdateBarRelatedLocation(ShakerLocation currentLoc)
    {
        switch (currentLoc)
        {
            case ShakerLocation.No:
                ScoreCheck(-bigScoreInc);
                break;
            case ShakerLocation.Little:
                ScoreCheck(-littleScoreInc);
                break;
            case ShakerLocation.Medium:
                ScoreCheck(littleScoreInc);
                break;
            case ShakerLocation.Heavy:
                ScoreCheck(bigScoreInc);
                break;
        }
    }

    /// <summary>
    /// Updates and manages the score changes
    /// </summary>
    /// <param name="scoreToUpdate">The desired score incermental</param>
    void ScoreCheck(int scoreToUpdate)
    {
        trasnlatedBarRelatedLocation += scoreToUpdate * scoreMultiplier;
        if (trasnlatedBarRelatedLocation <= 0)
        {
            trasnlatedBarRelatedLocation = 0;
            return;
        }
        if (trasnlatedBarRelatedLocation >= shakerMaxLimit)
        {
            trasnlatedBarRelatedLocation = shakerMaxLimit;
        }
        if (trasnlatedBarRelatedLocation > (linerTarget * 100) - onTargetOffset && trasnlatedBarRelatedLocation < (linerTarget * 100) + onTargetOffset)
        {
            shakerStatusBar.IndicateZoneOverlap();
            onTarget = true;
        }

        UpdateScoreUI();
    }

    /// <summary>
    /// Updated the score realted UI based on the changes made in the manager
    /// </summary>
    void UpdateScoreUI()
    {
        shakerStatusBar.UpdateScoreText((int)trasnlatedBarRelatedLocation);
        shakerStatusBar.LerpLocationIndicatorRect(Mathf.InverseLerp(0, shakerMaxLimit, trasnlatedBarRelatedLocation));
    }

    void CreateRandomDesignatedArea()
    {
        rndRange = Random.Range(20, 101);
        linerTarget = (float)rndRange / 100;
        shakerStatusBar.LerpDesgnatiedZoneRect(linerTarget);
    }
}