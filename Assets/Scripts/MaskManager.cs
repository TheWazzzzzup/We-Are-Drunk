using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MaskManager : MonoBehaviour
{
    [Header("Masks")]
    [SerializeField] Transform MaskParent;
    [Space]
    [SerializeField] Transform MaskFirst;
    [SerializeField] Transform MaskSecond;
    [SerializeField] Transform MaskThird;




    
    Vector3 LoadedV3;
    
    bool areMasksEqual = false;

    float currentHeight;

    private void Start()
    {
        LoadedV3 = new Vector3(0, -2, 0);
        MaskParent.position = LoadedV3;

        areMasksEqual = CheckForYSizeCons();
    }


    void MoveMask(float precentacge)
    {

    }



    void OverallLinerInterpolation(uint OrderInLayer)
    {
        if (!areMasksEqual)
        {
            Debug.LogWarning("The sizes does not match");
            return;
        }
        
        if (!(OrderInLayer < 3 && OrderInLayer > 0))
        {
            Debug.LogWarning("Order in layer does not make sense");
            return;
        }



    }





    // Checkers
    private bool CheckForYSizeCons()
    {
        if (MaskFirst.localScale.y == MaskSecond.localScale.y && MaskSecond.localScale.y == MaskThird.localScale.y)
        {
            return true;
        }

        else return false;
    }

}
