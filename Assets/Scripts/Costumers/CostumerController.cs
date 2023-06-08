using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for controlling the costumer.
/// </summary>
public class CostumerController : MonoBehaviour
{
    [SerializeField] CostumerData costumerData;
    [SerializeField] TweenMovement tweenMovement;
    [SerializeField] dialogue dialogue;

    public CostumerData CostumerData { get => costumerData; }

    internal Tween MoveTo(Vector3 position)
    {
        return tweenMovement.MoveTo(position);
    }

    internal void ShowDialogue(string dialogue)
    {
        this.dialogue.ShowDialogue(dialogue);
    }
}
