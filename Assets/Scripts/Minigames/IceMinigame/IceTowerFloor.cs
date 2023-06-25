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
        print("huh");
        if (collision.gameObject.tag != "IceCube")
        {
            return;
        }
        print("is ice cube");
        if(collision.gameObject.Equals(gameManager.CurrentIceCube.gameObject))
        {
            onFloorTouched.Invoke();
        }
    }
}
