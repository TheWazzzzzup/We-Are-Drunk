using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Shaker : MonoBehaviour , IPointerDownHandler
{
    [SerializeField] Rigidbody2D rb2;

    [Header("Height")]
    [SerializeField] float minimumY;
    [SerializeField] float maximumY;
    [Space]
    [Header("Side")]
    [SerializeField] float minimumX;
    [SerializeField] float maximumX;
    [Space]
    [Header("Rotation")]
    [SerializeField] float rotationThreshold;

    int shakerClickCount;

    float rndX;
    float rndY;

    Vector3 rotationVector;


    public void OnPointerDown(PointerEventData eventData)
    {
        ShakerClicked();
    }

    private void Awake()
    {
        rotationVector = Vector3.zero;
        rb2.simulated = false;
        shakerClickCount = 0;
    }

    private void Update()
    {
        // needs a replacement asap ! just a simulation check needs to be replaced by the minigame start 
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2.simulated = true;
        }
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

    void ObjectVelocityLauncher()
    {
        // Get the Y velocity
        int rnd = Random.Range(0, 101);
        rndY = LinerCalculation.InterpolateLinerLocation(rnd, minimumY,maximumY);
        // Get The X Velocity 
        rnd = Random.Range(0, 101);
        rndX = LinerCalculation.InterpolateLinerLocation(rnd, minimumX, maximumX);
        // Launch The actual Object
        rb2.velocity = new Vector2(rndX, rndY);

        // Rotate The Object
        RotateObject();
    }

    void RotateObject()
    {


        //transform.DORotate();
    }

}
