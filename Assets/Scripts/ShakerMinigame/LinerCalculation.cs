public static class LinerCalculation
{
    /// <summary>
    /// t = (P - P1) / (P0 - P1)
    /// </summary>
    /// <param name="locationOnScale"> (P) </param>
    /// <param name="minValue"> (P1) </param>
    /// <param name="maxValue"> (P0) </param>
    /// <returns></returns>
    public static float ExtractLinerLocation(float locationOnScale, float minValue, float maxValue)
    {
        return ((locationOnScale - minValue) / (maxValue - minValue)); 
    }

    /// <summary>
    /// P = (1 - t) * P0 + t * P1
    /// </summary>
    /// <param name="linerLocation"></param>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static float InterpolateLinerLocation(float linerLocation, float minValue, float maxValue)
    {
        return (1 - linerLocation) * maxValue + linerLocation * minValue;
    }


}
