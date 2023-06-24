using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceCube : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    public Rigidbody2D Rb { get => rb;}

    public void Sway(Transform otherSide, float time)
    {
        transform.DOMoveX(otherSide.position.x, time).SetEase(Ease.InOutExpo).SetLoops(-1);
    }

    [ContextMenu("drop")]
    public void Drop()
    {
        transform.DOKill();
        rb.simulated = true;
    }
}
