using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShakerMinigameStatusBar : MonoBehaviour
{
    [SerializeField] Image barBackground;
    [SerializeField] Image desgnitedZone;
    [SerializeField] Image LocationIndicator;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeOnTargetText;

    #region Height Limits
    // Height limits //Automated height limits to the images used in the status bar
    float barBackgroundHeight => barBackground.rectTransform.sizeDelta.y;

    float designtedZoneHeightLimit => (barBackgroundHeight / 2) - desgnitedZone.rectTransform.sizeDelta.y / 2;

    float LocationIndicatorHeightLimit => (barBackgroundHeight / 2) - (LocationIndicator.rectTransform.sizeDelta.y + 20) / 2;
    #endregion

    public void UpdateScoreText(float score)
    {
        scoreText.text = score.ToString();
    }

    public void IndicateZoneOverlap()
    {
        // TODO: create indication of the overlap between the zone and the actual location
        Debug.Log("Overlap Zone and Image");
    }

    /// <summary>
    /// Change the time on target represnation in UI
    /// </summary>
    /// <param name="time">The desired time to show</param>
    public void ChangeRandomTimeOnTarget(float time)
    {
        timeOnTargetText.text = time.ToString();
    }

    /// <summary>
    /// Places the rect location of the desgnatied zone using liner calculation
    /// </summary>
    /// <param name="lerpLocation">Liner location (Between 0 - 1)</param>
    public void LerpDesgnatiedZoneRect(float lerpLocation)
    {
        float linerLoc = Mathf.Lerp(-designtedZoneHeightLimit, designtedZoneHeightLimit, lerpLocation);
        Vector2 V2Loc = new Vector2(0, linerLoc);
        desgnitedZone.rectTransform.localPosition = V2Loc;
    }

    /// <summary>
    /// Places the rect location of the Location Indicator using liner calculation
    /// </summary>
    /// <param name="lerpLocation">Liner location (Between 0 - 1)</param>
    public void LerpLocationIndicatorRect(float lerpLocation)
    {
        float linerLoc = Mathf.Lerp(-LocationIndicatorHeightLimit, LocationIndicatorHeightLimit, lerpLocation);
        Vector2 V2Loc1 = new Vector2(0, linerLoc);
        LocationIndicator.rectTransform.localPosition = V2Loc1;
    }
}
