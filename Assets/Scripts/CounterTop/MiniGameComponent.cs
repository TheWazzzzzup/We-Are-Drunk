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

    public UnityEvent OnMinigamesReady = new();
    public UnityEvent OnMinigamesDeactive = new();
    public UnityEvent OnMinigamesDone = new();

    // Serialze
    [SerializeField] MinigameType minigameType;

    [SerializeField] Transform spawnLocationOnCompleted;

    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] SpriteRenderer glowRenderer;


    // Private

    Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

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
        float tweenDuration = 0.7f;
        minigameState = state;
        switch (minigameState)
        {
            case MinigameState.Deactiveated:
                glowRenderer.gameObject.SetActive(false);
                spriteRenderer.DOColor(Color.black, tweenDuration);
                transform.localScale = originalScale;
                break;
            case MinigameState.Active:
                glowRenderer.gameObject.SetActive(true);
                OnMinigamesReady.Invoke();
                ReadyTween(tweenDuration);
                break;
            case MinigameState.InProgress:
                MinigameProgress();
                break;
            case MinigameState.Done:
                MinigameCompleted();
                glowRenderer.gameObject.SetActive(false);
                spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1);
                break;
        }
    }

    private void ReadyTween(float tweenDuration)
    {
        transform.DOShakeRotation(tweenDuration, new Vector3(0, 0, 20), 15, 1, false, ShakeRandomnessMode.Harmonic);
        transform.DOScale(originalScale * 1.3f, tweenDuration / 2).SetEase(Ease.OutSine).OnComplete(() => transform.DOScale(originalScale, tweenDuration / 2));
        spriteRenderer.DOColor(Color.white, tweenDuration);
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
