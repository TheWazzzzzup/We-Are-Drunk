using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGameComponent : MonoBehaviour
{
    // Public


    // Serialze
    [SerializeField] MinigameType minigameType;

    [SerializeField] Transform spawnLocationOnCompleted;

    [SerializeField] SpriteRenderer spriteRenderer;


    // Private
    MinigameState minigameState;

    private void OnMouseDown()
    {
        OnTriggerEnter2D(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (minigameState == MinigameState.Active)
        {
            {
                minigameState = MinigameState.InProgress;
                StateOverseer(MinigameState.InProgress);
            }
        }
    }

    void MinigameProgress()
    {
        // Place holder, should be replaced with script specific minigame
        Debug.Log("Player Initated The Minigame");

        // just for check
        StateOverseer(MinigameState.Done);
    }

    void MinigameCompleted()
    {
        // what happens when the minigame is completed
        // here enters elad example about the Sprtie you can drag
        Debug.Log($"{minigameType.ToString()} minigame is completed");
    }

    public void SetMinigameActivision(bool canMinigame)
    {
        if (canMinigame) StateOverseer(MinigameState.Active);
        else StateOverseer(MinigameState.Deactiveated); 
    }

    void StateOverseer(MinigameState state)
    {
        minigameState = state;
        switch (minigameState)
        {
            case MinigameState.Deactiveated:
                spriteRenderer.color = Color.black;
                break;
            case MinigameState.Active:
                spriteRenderer.color = Color.white;
                break;
            case MinigameState.InProgress:
                MinigameProgress();
                break;
            case MinigameState.Done:
                MinigameCompleted();
                break;
        }
    }
}

enum MinigameType
{
    Float,
    Ice,
    Craft
}

enum MinigameState
{
    Deactiveated,
    Active,
    InProgress,
    Done
}
