using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] int maxIngredientAmount = 4;
    [SerializeField] Item[] items;
    [SerializeField] bool isFull = false;

    private void Awake()
    {
        items = new Item[maxIngredientAmount];
    }

    private void OnMouseUp()
    {
        if (isFull)
        {
            return;
        }

        if (items[0] == null && CraftingManager.Instance.CurrentItem.Type != IngredientType.Alcohol)
        {
            print("base must be alcohol");
            return;
        }

        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                continue;
            }
            items[i] = CraftingManager.Instance.CurrentItem;
            break;
        }

        CraftingManager.Instance.UpdateCupVisuals();
        CraftingManager.Instance.ClearCurrentItem();

        if (CheckIfFull())
        {
            isFull = true;
        }

        if(isFull)
        {
            //TODO compare recipe method
        }

    }


    public bool CheckIfFull()
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void ClearItems()
    {
        items = new Item[maxIngredientAmount];
        isFull = false;
    }
}
