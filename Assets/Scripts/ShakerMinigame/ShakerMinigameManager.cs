using UnityEngine;

public class ShakerMinigameManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] CheckShakerMinigameCollisions shakerCollision; 
    [SerializeField] ShakerMinigameStatusBar shakerStatusBar;
    [SerializeField] ShakerMinigameComponent shakerComponent;

    [Header("Score")]
    [SerializeField] int littleScoreInc; // The small score Incremental to the bar related location
    [SerializeField] int bigScoreInc; // The bigger score Incremental to the bar related location
    [SerializeField] float scoreMultiplier; // The score multiplier to the bar related location, called in fixed update

    [Header("Target")]
    [SerializeField] float goalTimeOnTarget = 5f; // The goal time the player needs to reach when on target
    [SerializeField] int onTargetOffset; // The location offset the player is allowed in order to stay on target
    [SerializeField] int miniGameTimeFrame;

    /// <summary>
    /// Wheter or not the player is currntly on target
    /// </summary>
    bool onTarget;
    bool minigameStarted = false;
    bool minigameEnded = false;

    // Related Location
    float trasnlatedBarRelatedLocation = 0;
    float linerTarget; // the liner represantion of the score related location
    int shakerMaxLimit = 100;

    // Timer
    float totalTimeOnTarget; // updated time the player has on target
    float overallTime;       // Updated time from the start of the minigame

    // Disposable (Memory Saver / Preoptimization)
    int rndRange;

    private void Start()
    {
        CreateRandomDesignatedArea();
        shakerStatusBar.ChangeRandomTimeOnTarget(goalTimeOnTarget);
        totalTimeOnTarget = goalTimeOnTarget;
        
        // Minigame Started (should be moved !)
        InitiateGameStart();                        
    }

    public bool GetMinigameEnded() => minigameEnded;

    private void InitiateGameStart()
    {
        shakerComponent.MinigameStarted();
        minigameStarted = true;
    }

    private void FixedUpdate()
    {
        UpdateBarRelatedLocation(shakerCollision.Location);

        if (minigameStarted)
        {
            overallTime += Time.fixedDeltaTime;

            if (overallTime >= miniGameTimeFrame)
            {
                ShakerGameOver();
            }

        }

        if (onTarget)
        {
            totalTimeOnTarget -= Time.fixedDeltaTime; // reduce the time by using the delta time incrementals
            if (totalTimeOnTarget <= 0f)
            {
                // TODO add game ended logic
                ShakerGameOver();
                totalTimeOnTarget = 0;
            }
            shakerStatusBar.ChangeRandomTimeOnTarget(totalTimeOnTarget);
        }
    }

    private void ShakerGameOver()
    {
           Debug.Log("Game Over");
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
        if (trasnlatedBarRelatedLocation > (linerTarget * 100) - onTargetOffset && trasnlatedBarRelatedLocation < (linerTarget * 100) + onTargetOffset)
        {
            shakerStatusBar.IndicateZoneOverlap();
            onTarget = true;
        }

        else
        {
            onTarget = false;
        }

        if (trasnlatedBarRelatedLocation <= 0)
        {
            trasnlatedBarRelatedLocation = 0;
            return;
        }
        if (trasnlatedBarRelatedLocation >= shakerMaxLimit)
        {
            trasnlatedBarRelatedLocation = shakerMaxLimit;
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
        rndRange = Random.Range(20, 75);
        linerTarget = (float)rndRange / 100;
        shakerStatusBar.LerpDesgnatiedZoneRect(linerTarget);
    }
}