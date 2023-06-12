using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MiniGameComponent : MonoBehaviour
{
    // Public
    public UnityEvent OnClick;
    public MinigameState minigameState { get; private set; }


    // Serialze
    [SerializeField] MinigameType minigameType;

    [SerializeField] Transform spawnLocationOnCompleted;

    [SerializeField] SpriteRenderer spriteRenderer;

    
    // Private

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

    public MinigameType GetMiniType => minigameType; 

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
                spriteRenderer.DOColor(Color.black, 2.5f);
                break;
            case MinigameState.Active:
                spriteRenderer.DOColor(Color.white, 2.5f) ;
                break;
            case MinigameState.InProgress:
                MinigameProgress();
                break;
            case MinigameState.Done:
                MinigameCompleted();
                break;
        }
    }
    
    void MinigameProgress()
    {
        // Place holder, should be replaced with script specific minigame
        Debug.Log("Player Initated The Minigame");
        OnClick.Invoke();

        // just for check
    }
    
    void MinigameCompleted()
    {
        GameObject gameObject = new();
        gameObject.transform.position = spawnLocationOnCompleted.position;
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2d =  gameObject.AddComponent<BoxCollider2D>();
        boxCollider2d.size = Vector2.one;
        gameObject.AddComponent<DraggableObject>();
        sr.sprite = spriteRenderer.sprite;
        // what happens when the minigame is completed
        // here enters elad example about the Sprtie you can drag
        Debug.Log($"{minigameType.ToString()} minigame is completed");
    }

    public void MinigameToggleComplete()
    {
        StateOverseer(MinigameState.Done);
    }
}

public enum MinigameType
{
    Float,
    Ice,
    Craft
}

public enum MinigameState
{
    Deactiveated,
    Active,
    InProgress,
    Done
}
