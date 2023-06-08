using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("EventAggregator/IngredientGameEvent"))]
public class IngredientGameEvent : ScriptableObject
{
    public List<IngredientGameEventListener> listeners = new();

    public void Raise(Ingredient ingredient) {
        Debug.Log(ingredient.name);
        for (int i = 0; i < listeners.Count; i++) {
            listeners[i].OnEventRaised(ingredient);
        }
    }

    public void RegisterListener(IngredientGameEventListener listener) {
        if (!listeners.Contains(listener)) listeners.Add(listener);
        else Debug.LogWarning("Listener allready registerd");
    
    }

    public void UnregisterListener(IngredientGameEventListener listener) {
        if (listeners.Contains(listener)) listeners.Remove(listener);
    }
}
