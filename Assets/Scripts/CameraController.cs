using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private const float cameraDuration = .6f;

    [SerializeField] Camera cam;

    [SerializeField] Transform BarLoc;

    [SerializeField] Transform InventoryLoc;

    [SerializeField] Transform CraftLoc;

    [SerializeField] Transform IceLoc;

    [SerializeField] Transform FloatLoc;

    bool canGoToInventory = true;

    int sceneUnloadNum;
    int sceneLoadNum;

    Tween tween;
    public MainSceneCameraState currentState { get; private set; } = MainSceneCameraState.Bar;
    public MainSceneCameraState previousState { get; private set; } = MainSceneCameraState.Bar;

    private void Start()
    {
        cam.transform.position = BarLoc.position;
    }

    public void ResetAbilityForInventory() {
        canGoToInventory = true;
    }

    public void MoveToFloat()
    {
        cam.transform.DOMove(FloatLoc.position, cameraDuration).SetEase(Ease.OutCubic);
        canGoToInventory = false;
    }


    public void MoveToIce()
    {
        tween = cam.transform.DOMove(IceLoc.position, cameraDuration).SetEase(Ease.OutCubic);
        sceneLoadNum = 2;
        tween.OnComplete(TransitionCompleted);
        canGoToInventory = false;
    }

    public void MoveToBar()
    {
        cam.transform.DOMove(BarLoc.position, cameraDuration).SetEase(Ease.OutCubic).OnComplete(() => currentState = MainSceneCameraState.Bar);
        currentState = MainSceneCameraState.Transitioning;
    }

    public void MoveToBar(int sceneToUnload)
    {
        sceneUnloadNum = sceneToUnload;
        tween = cam.transform.DOMove(BarLoc.position, cameraDuration).SetEase(Ease.OutCubic).OnComplete(() => currentState = MainSceneCameraState.Bar);
        tween.OnComplete(BackTransitionCompleted);
        currentState = MainSceneCameraState.Transitioning;
    }

    public void MoveToInventory()
    {
        if (!canGoToInventory)
            return;
        cam.transform.DOMove(InventoryLoc.position, cameraDuration).SetEase(Ease.OutCubic).OnComplete(() => currentState = MainSceneCameraState.Inventory);
        currentState = MainSceneCameraState.Transitioning;
    }

    public void MoveToCraft()
    {
        tween = cam.transform.DOMove(CraftLoc.position, cameraDuration).SetEase(Ease.OutCubic);
        sceneLoadNum = 1;
        tween.OnComplete(TransitionCompleted);

        canGoToInventory = false;
    }

    void TransitionCompleted()
    {
        SceneManager.LoadScene(sceneLoadNum, LoadSceneMode.Additive);
    }

    void BackTransitionCompleted()
    {
        SceneManager.UnloadScene(sceneUnloadNum);
    }
}

public enum MainSceneCameraState
{
    Bar,
    Transitioning,
    Inventory
}
