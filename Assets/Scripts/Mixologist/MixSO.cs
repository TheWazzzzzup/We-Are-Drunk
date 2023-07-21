using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MixBookComponent" , menuName = "ScriptableObjects/Mixologist Book Entry")]
public class MixSO : ScriptableObject
{
    public Sprite drinkSprite;
    public RecipeDataSO recipe ;

}
