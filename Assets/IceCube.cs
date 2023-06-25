using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceCube : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider;


    IceCubeState currentState;

    public Rigidbody2D Rb { get => rb;}
    public IceCubeState CurrentState { get => currentState;}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentState != IceCubeState.Dropping)
            return;

        if(collision.gameObject.tag == "IceCube")
        {

        }
    }

    public void Initialize(Transform otherSide, float time, float scale)
    {
        currentState = IceCubeState.Swaying;
        transform.localScale *= scale;
        Sway(otherSide, time);
    }

    public void Sway(Transform otherSide, float time)
    {
        transform.DOMoveX(otherSide.position.x, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    [ContextMenu("drop")]
    public void Drop()
    {
        transform.DOKill();
        currentState = IceCubeState.Dropping;
        rb.simulated = true;
    }

    public void SetIceCubeStable()
    {
        currentState = IceCubeState.Stable;
    }

    public enum IceCubeState
    {
        Swaying,
        Dropping,
        Stable
    }
}
