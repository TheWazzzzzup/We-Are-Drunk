using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IceTowerFloor : MonoBehaviour
{
    public UnityEvent onFloorTouched = new UnityEvent();

    [SerializeField] IceTowerGameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "IceCube")
        {
            return;
        }
        if(collision.gameObject.Equals(gameManager.CurrentIceCube.gameObject))
        {
            onFloorTouched.Invoke();
        }
    }
}
