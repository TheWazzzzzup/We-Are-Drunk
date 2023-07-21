using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupDraggableHolder : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(BarManager.Instance.AllMinigamesCompleted && !BarManager.Instance.DrinkCompleted)
        {
            BarManager.Instance.HandInDrink();
        }
    }
}
