using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryTransitionTrigger : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] CameraController cameraController;
    [SerializeField] BarManager barManager;


    public void OnPointerEnter(PointerEventData eventData)
    {
        switch(cameraController.currentState)
        {
            case MainSceneCameraState.Bar:
                cameraController.MoveToInventory();
                break;
            case MainSceneCameraState.Transitioning: break;
            case MainSceneCameraState.Inventory:
                cameraController.MoveToBar();
                barManager.GetInventory();
                break;
        }
    }
}