using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRen;

    bool isHoldingSprite => spriteRen.sprite != null;

    public void PassSprite(SpriteRenderer sr)
    {
        spriteRen.sprite = sr.sprite;
    }

    private void Update()
    {
        Debug.Log(isHoldingSprite);
        if (isHoldingSprite)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            transform.position = mousePosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
