using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        rb.gravityScale = 0;
    }

    [Button]
    public void Drop()
    {
        rb.velocity = Vector3.zero;

        //drop the object
        rb.gravityScale = 1;

    }
}
