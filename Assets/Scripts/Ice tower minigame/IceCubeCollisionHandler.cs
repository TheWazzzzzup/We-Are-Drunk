using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to handle the collision logic of the ice cube in the ice tower minigame
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class IceCubeCollisionHandler : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public event Action<Collision2D> OnIceCubeCollision;
    public event Action OnIceCubeStopped;

    bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //sent collision event to the listeners
        OnIceCubeCollision?.Invoke(collision);

        //set the hasCollided flag to true
        hasCollided = true;
    }

    private void Update()
    {
        if (!hasCollided)
        {
            return;
        }

        //if the ice cube is not moving anymore, we inform the lisetern that it had stopped
        if (rb.velocity.magnitude < 0.1f)
        {
            OnIceCubeStopped?.Invoke();
            hasCollided = false;
        }
    }
}
