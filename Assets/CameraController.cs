using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
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
        cam.transform.DOMove(FloatLoc.position, 1.2f).SetEase(Ease.OutCubic);

    }


    public void MoveToIce()
    {
        cam.transform.DOMove(IceLoc.position, 1.2f).SetEase(Ease.OutCubic);

    }

    public void MoveToBar()
    {
        cam.transform.DOMove(BarLoc.position, 1.2f).SetEase(Ease.OutCubic);
    }

    public void MoveToInventory()
    {
        cam.transform.DOMove(InventoryLoc.position, 1.2f).SetEase(Ease.OutCubic);
    }

    public void MoveToCraft()
    {
        cam.transform.DOMove(CraftLoc.position, 1.2f).SetEase(Ease.OutCubic);
    }


}
