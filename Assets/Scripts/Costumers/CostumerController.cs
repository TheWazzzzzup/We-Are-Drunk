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
    [SerializeField] TweenMovement tweenMovement;
    [SerializeField] dialogue dialogue;
    
    CostumerData costumerData;

    public CostumerData CostumerData { get => costumerData; set => costumerData = value; }

    internal Tween MoveTo(Vector3 position)
    {
        return tweenMovement.MoveTo(position);
    }

    internal void ShowDialogue(string dialogue)
    {
        this.dialogue.ShowDialogue(dialogue);
    }

}
