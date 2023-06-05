using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement of the costumer in and out the bar
/// </summary>
public class CostumerMovementController : MonoBehaviour
{
    #region Members

    [SerializeField] private float speed = 1f;
    [SerializeField] AnimationCurve animationCurve;

    #endregion

     public void MoveTo(Vector2 position)
    {
        //calculate duration
        float distance = Vector2.Distance(transform.position, position);
        float duration = distance / speed;

        transform.DOMove(position, duration).SetEase(animationCurve);
    }
}
