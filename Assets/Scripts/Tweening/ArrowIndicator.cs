using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField, OnStateUpdate("Oriented")] bool isPointUp;
    [SerializeField] float bobSpeed = 2.0f;
    [SerializeField] float bobHeight = 0.25f;

    Vector3 startPosition;


    private void Start()
    {
        Oriented();

        //Bob up and down
        startPosition = transform.position;
        transform.DOMoveY(transform.position.y + bobHeight, bobSpeed)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

    }



    public void Oriented()
    {
        if (isPointUp)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }


}
