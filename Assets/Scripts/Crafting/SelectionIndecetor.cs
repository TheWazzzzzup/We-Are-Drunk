using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionIndecetor : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color selectedColor, unselectedColor;

    private void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void SetSelected(bool selected)
    {
        image.color = selected ? selectedColor : unselectedColor;
    }
}
