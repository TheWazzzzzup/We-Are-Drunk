using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class ShakerMinigameComponent : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Rigidbody2D rb2;

    [Header("Height")]
    [SerializeField] float minimumY;
    [SerializeField] float maximumY;
    [Space]
    [Header("Side")]
    [SerializeField] float xThreshold;
    [Space]

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
            MinigameStarted();
        }
    }

    public void MinigameStarted()
    {
        rb2.simulated = true;
    }

    void ShakerClicked()
    {
        ObjectVelocityLauncher();
    }

    /// <summary>
    /// Launches the minigame components in a random upward velocity 
    /// </summary>
    void ObjectVelocityLauncher()
    {
        // Get the Y velocity
        int rnd = Random.Range(0, 101);
        rndY = LinerCalculation.InterpolateLinerLocation((float)rnd / 100, minimumY, maximumY);
        // Get The X Velocity 
        rnd = Random.Range(0, 101);
        rndX = LinerCalculation.InterpolateLinerLocation((float)rnd / 100, xThreshold * -1, xThreshold);
        // Launch The actual Object
        rb2.velocity = new Vector2(rndX, rndY);

    }

    void MinigameSetInitalFields()
    {
        rotationVector = Vector3.zero;
        rb2.simulated = false;
    }

}