using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] bool isPointUp;
    [SerializeField] float bobSpeed = 2.0f;
    [SerializeField] float bobHeight = 0.25f;

    Vector3 startPosition;


    private void Start()
    {
        Orient();

        //Bob up and down
        startPosition = transform.position;
        transform.DOMoveY(transform.position.y + bobHeight, bobSpeed)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

    }

    public void SetOrientation(bool isUp)
    {
        isPointUp = isUp;
        Orient();
    }

    public void Flip()
    {
        SetOrientation(!isPointUp);
    }

    public void Orient()
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
