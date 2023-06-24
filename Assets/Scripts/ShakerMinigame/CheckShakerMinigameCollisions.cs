using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckShakerMinigameCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("No"))
        {

        }
        if (collision.CompareTag("Little"))
        {

        }
        if (collision.CompareTag("Medium"))
        {

        }
        if (collision.CompareTag("Heavy"))
        {

        }
    }

    
}
