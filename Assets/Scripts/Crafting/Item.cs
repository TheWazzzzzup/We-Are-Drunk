using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private IngredientName iName;
    [SerializeField] private IngredientType iType;

    public IngredientName Name { get { return iName; } }
    public IngredientType Type { get { return iType; } }

    private void OnMouseDown()
    {
        CraftingManager.Instance.OnMouseDownItem(this);
    }
}
