using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGameComponent : MonoBehaviour
{
    // Public


    // Serialze
    [SerializeField] MinigameType minigameType;

    [SerializeField] Transform spawnLocationOnCompleted;

    [SerializeField] SpriteRenderer spriteRenderer;
    

    // Private
    BarManager barManager;

    bool isMiniPlayable => barManager.CanMinigame();


    public void BarInsert(BarManager barManager)
    {
        this.barManager = barManager;
    }

    private void FixedUpdate()
    {
        if (isMiniPlayable)
        {
            spriteRenderer.color = Color.white;
        }
    }


}

enum MinigameType
{
    Float,
    Ice,
    Craft
}
