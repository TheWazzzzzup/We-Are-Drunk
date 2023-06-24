using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenBackAndForthMovement : TweenMovement
{
    [Button]
    public Sequence MoveBackAndForth(Vector2 from, Vector2 to)
    {
        return DOTween.Sequence()
            .Append(MoveTo(from))
            .Append(MoveTo(to))
            .SetLoops(-1, LoopType.Yoyo);
    }
}
