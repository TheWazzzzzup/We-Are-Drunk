using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeController : MonoBehaviour
{
    [SerializeField] ItemDrop itemDrop;
    [SerializeField] TweenBackAndForthMovement tweenBackAndForth;

    [SerializeField] Vector2 moveToGoal; //The cube would move from it's original position to this position and back

    Sequence moveSequence;

    private void Start()
    {
        moveSequence = tweenBackAndForth.MoveBackAndForth(transform.position, moveToGoal);
    }

    private void Update()
    {
        //when the player click or press space we drop the cube
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            //drop the cube
            moveSequence.OnKill(() => itemDrop.Drop());
            //stop the tween movement
            moveSequence.Kill();

        }
    }
}
