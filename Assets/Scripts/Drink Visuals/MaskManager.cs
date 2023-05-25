using UnityEngine;

public class MaskManager : MonoBehaviour
{
    [Header("Masks")]
    [SerializeField] Transform MaskParent;
    [Space]
    [SerializeField] Transform MaskFirst;
    [SerializeField] Transform MaskSecond;
    [SerializeField] Transform MaskThird;

    Vector3 loadedV3;

    bool areMasksEqual = false;

    uint currentMaskInOrder;
    
    float currentPrecentage = 0f;
    float minimunSize = 0f;
    float maximunSize = 0f;

    // * * This is temporary value, needs to be change this with logic based on given sprites. very and bug proneable ! ! !
    float offset = -2f;

    private void Start()
    {
        loadedV3 = new Vector3(0, offset, 0);
        MaskParent.position = loadedV3;

        areMasksEqual = CheckForYSizeCons();
        if (areMasksEqual)
        {
            maximunSize = MaskFirst.transform.localScale.y;
        }
    }

    /// <summary>
    /// Slides the wanted mask via precentage interpolation
    /// </summary>
    /// <param name="precentageToAdd">the precentage you wish to add in to the drink layer</param>
    /// <param name="OrderInLayer">The drink layer you wish to reveal</param>
    public void SlideMasks(float precentageToAdd, uint OrderInLayer)
    {
        MoveMask(currentPrecentage + precentageToAdd, OrderInLayer);
    }

    /// <summary>
    /// Incharge of the mask sliding logic
    /// </summary>
    /// <param name="precentacge">Value between 0 - 100</param>
    /// <param name="OrderInLayer">Value between 0 - 2</param>
    void MoveMask(float precentacge, uint OrderInLayer)
    {

        if (!(precentacge >= 0 && precentacge < 101))
        {
            Debug.LogWarning("Precentage is out of range");
            return;
        }

        currentMaskInOrder = OrderInLayer;
        switch (OrderInLayer)
        {
            case 0:
                MaskParent.position = new Vector3(0, LinerInterpolationToLoc(precentacge),0);
                break;
            case 1:
                MaskSecond.position = new Vector3(0, LinerInterpolationToLoc(precentacge), 0);
                break;
            case 2:
                MaskThird.position = new Vector3(0, LinerInterpolationToLoc(precentacge), 0);
                break;
            default:
                Debug.LogWarning("Order in layer does not make sense");
                break;
        }
    }


    // Returns the Y location interpolated by the precentage
    float LinerInterpolationToLoc(float precentacge)
    {
        currentPrecentage = (precentacge - 0) / (100 - 0);
        return (minimunSize + currentPrecentage * (maximunSize - minimunSize) + offset);
    }


    // Checkers
    private bool CheckForYSizeCons()
    {
        if (MaskFirst.localScale.y == MaskSecond.localScale.y && MaskSecond.localScale.y == MaskThird.localScale.y)
        {
            return true;
        }

        else
        {
            Debug.LogWarning("The sizes does not match");
            return false;
        } 
    }

    #region Debug
    [ContextMenu("ShizCheck")]
    public void MoveMask()
    {

        if (!(currentPrecentage >= 0 && currentPrecentage < 101))
        {
            Debug.LogWarning("Precentage is out of range");
            return;
        }

        currentMaskInOrder = currentMaskInOrder;
        switch (currentMaskInOrder)
        {
            case 0:
                MaskParent.position = new Vector3(0, LinerInterpolationToLoc(currentPrecentage), 0);
                break;
            case 1:
                MaskSecond.position = new Vector3(0, LinerInterpolationToLoc(currentPrecentage), 0);
                break;
            case 2:
                MaskThird.position = new Vector3(0, LinerInterpolationToLoc(currentPrecentage), 0);
                break;
            default:
                Debug.LogWarning("Order in layer does not make sense");
                break;
        }
    }
    #endregion
}
