using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("EventAggregator/MiniGameEvent"))]
public class MinigameEvent : ScriptableObject
{
    public List<MinigameEventListener> listeners = new();

    public void Raise(GameObject gameObject, MinigameType type)
    {
        Debug.Log(gameObject);
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(gameObject,type);
        }
    }

    public void RegisterListener(MinigameEventListener listener)
    {
        if (!listeners.Contains(listener)) listeners.Add(listener);
        else Debug.LogWarning("Listener allready registerd");

    }

    public void UnregisterListener(MinigameEventListener listener)
    {
        if (listeners.Contains(listener)) listeners.Remove(listener);
    }
}
