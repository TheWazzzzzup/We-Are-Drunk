using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    [SerializeField] RecipeDataSO data;
    [SerializeField] bool discovered = false;



    public void Discovered()
    {
        discovered = true;
    }
}
