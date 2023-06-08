using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class IngredientGameEventListener : MonoBehaviour
{
    [SerializeField] IngredientGameEvent gameEvent;

    [SerializeField] IngredientUnityEvent response; 

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(Ingredient ingredient)
    {
        response.Invoke(ingredient);
    }
}

[System.Serializable]
public class IngredientUnityEvent : UnityEvent<Ingredient> {}