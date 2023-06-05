using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour , IPointerDownHandler
{
    GameObject objectClickedOn;
    Vector3 mouseClickVector;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0)) Debug.Log("Mouse Pressed");
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Pressed omd");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerWorks");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        Debug.Log($"hitted {hit.transform.gameObject.name}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        throw new System.NotImplementedException();
    }

    public void Debugem()
    {
        Debug.Log("Event trigger");
    }
}

