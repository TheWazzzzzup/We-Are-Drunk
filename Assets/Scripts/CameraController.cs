using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private const float cameraDuration = .6f;

    [SerializeField] Camera cam;

    [SerializeField] Transform BarLoc;

    [SerializeField] Transform InventoryLoc;

    [SerializeField] Transform CraftLoc;

    [SerializeField] Transform IceLoc;

    [SerializeField] Transform FloatLoc;


    private void Start()
    {
        cam.transform.position = BarLoc.position;
    }

    public void MoveToFloat()
    {
        cam.transform.DOMove(FloatLoc.position, cameraDuration).SetEase(Ease.OutCubic);

    }


    public void MoveToIce()
    {
        cam.transform.DOMove(IceLoc.position, cameraDuration).SetEase(Ease.OutCubic);

    }

    public void MoveToBar()
    {
        cam.transform.DOMove(BarLoc.position, cameraDuration).SetEase(Ease.OutCubic);
    }

    public void MoveToInventory()
    {
        cam.transform.DOMove(InventoryLoc.position, cameraDuration).SetEase(Ease.OutCubic);
    }

    public void MoveToCraft()
    {
        cam.transform.DOMove(CraftLoc.position, cameraDuration).SetEase(Ease.OutCubic);
    }


}
