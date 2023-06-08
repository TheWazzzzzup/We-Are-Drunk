using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MixBookComponent" , menuName = "ScriptableObjects/Mixologist Book")]
public class MixSO : ScriptableObject
{
    public Sprite drinkSprite;
    public RecipeDataSO recipe ;
    [Range(0,5)]
    public int difficutly; // can be represented with start in the furute

}
