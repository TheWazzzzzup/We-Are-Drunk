using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class ShakerMinigameComponent : MonoBehaviour , IPointerDownHandler
{
    [SerializeField] Rigidbody2D rb2;

    [Header("Height")]
    [SerializeField] float minimumY;
    [SerializeField] float maximumY;
    [Space]
    [Header("Side")]
    [SerializeField] float xThreshold;
    [Space]
    [Header("Rotation")]
    [SerializeField] float rotationThreshold;
    [SerializeField] float rotationTime;

    int shakerClickCount;

    float rndX;
    float rndY;
    float rndRot;

    Vector3 rotationVector;


    public void OnPointerDown(PointerEventData eventData)
    {
        ShakerClicked();
    }

    private void Awake()
    {
        MinigameSetInitalFields();
    }

    private void Update()
    {
        // needs a replacement asap ! just a simulation check needs to be replaced by the minigame start 
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2.simulated = true;
        }
    }

    public void MinigameStarted()
    {
        rb2.simulated = true;
    }

    void ShakerClicked()
    {
        UpdateScore();
        ObjectVelocityLauncher();
    }

    void UpdateScore()
    {
        shakerClickCount++;
    }

    /// <summary>
    /// Launches the minigame components in a random upward velocity 
    /// </summary>
    void ObjectVelocityLauncher()
    {
        // Get the Y velocity
        int rnd = Random.Range(0, 101);
        rndY = LinerCalculation.InterpolateLinerLocation((float)rnd/100, minimumY,maximumY);
        // Get The X Velocity 
        rnd = Random.Range(0, 101);
        rndX = LinerCalculation.InterpolateLinerLocation((float)rnd/100, xThreshold * -1, xThreshold);
        // Rotate The Object
        RotateObject();
        // Launch The actual Object
        rb2.velocity = new Vector2(rndX, rndY);

    }

    /// <summary>
    /// Rotates the minigame component
    /// </summary>
    void RotateObject()
    {
        int rnd = Random.Range(0, 101);
        rndRot = LinerCalculation.InterpolateLinerLocation((float)rnd / 100, rotationThreshold * -1, rotationThreshold);
        rotationVector = new Vector3(0, 0, rndRot);
        transform.DORotate(rotationVector,rotationTime);
    }

    void MinigameSetInitalFields()
    {
        rotationVector = Vector3.zero;
        rb2.simulated = false;
        shakerClickCount = 0;
    }

}
