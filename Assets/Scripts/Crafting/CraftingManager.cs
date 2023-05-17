using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager Instance;

    [SerializeField] Item currentItem;
    [SerializeField] SpriteRenderer[] drinkParts;
    [SerializeField] Cup cup;

    public Item CurrentItem { get { return currentItem; }}


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void OnMouseDownItem(Item item)
    {
        if(CurrentItem == null || CurrentItem != item)
        {
            currentItem = item;
        }
    }

    public void UpdateCupVisuals()
    {
        for(int i = 0; i < drinkParts.Length; i++)
        {
            if(drinkParts[i].enabled)
            {
                continue;
            }

            drinkParts[i].enabled = true;
            drinkParts[i].color = currentItem.gameObject.GetComponent<SpriteRenderer>().color;
            break;
        }
    }

    public void ClearCup()
    {
        foreach(var p in drinkParts)
        {
            p.enabled = false;
        }
        cup.ClearItems();
    }

    public void ClearCurrentItem()
    {
        currentItem = null;
    }
}
