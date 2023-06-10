using UnityEngine;

[RequireComponent(typeof(Ingredient))]
public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        transform.position = startingPos;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}