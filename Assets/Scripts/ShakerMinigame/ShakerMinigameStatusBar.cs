using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShakerMinigameStatusBar : MonoBehaviour
{
    [SerializeField] Image barBackground;
    [SerializeField] Image desgnitedZone;
    [SerializeField] Image LocationIndicator;

    [Range(0,1)]
    public float desgnitedZonePlacing;

    [Range(0, 1)]
    public float locationIndicatorPlacing;

    float barBackgroundHeight => barBackground.rectTransform.sizeDelta.y;

    // The are in which the image can be move inside (pos,neg) has to be a child of the barBackground
    // Need to be offseted if we add our own sprite
    float designtedZoneHeightLimit => (barBackgroundHeight /2) - desgnitedZone.rectTransform.sizeDelta.y / 2;


    private void OnValidate()
    {
        float loc = Mathf.Lerp(-designtedZoneHeightLimit, designtedZoneHeightLimit, desgnitedZonePlacing);
        LerpDesgnatiedZoneRect(loc);
        
        float loc1 = Mathf.Lerp(-designtedZoneHeightLimit,designtedZoneHeightLimit, locationIndicatorPlacing);
       LerpLocationIndicatorRect(loc1);

        //  TODO:
        //  Create a calculation that will make this fit
        //  *NOTICE* make sure the showing of the changes is making sense as well
    }

    /// <summary>
    /// Places the rect location of the desgnatied zone using liner calculation
    /// </summary>
    /// <param name="lerpLocation">Liner location (Between 0 - 1)</param>
    public void LerpDesgnatiedZoneRect(float lerpLocation)
    {
        Vector2 V2Loc = new Vector2(0, lerpLocation);
        desgnitedZone.rectTransform.localPosition = V2Loc;
    }

    /// <summary>
    /// Places the rect location of the Location Indicator using liner calculation
    /// </summary>
    /// <param name="lerpLocation">Liner location (Between 0 - 1)</param>
    public void LerpLocationIndicatorRect(float lerpLocation)
    {
        Vector2 V2Loc1 = new Vector2(0, lerpLocation);
        LocationIndicator.rectTransform.localPosition = V2Loc1;
    }
}
