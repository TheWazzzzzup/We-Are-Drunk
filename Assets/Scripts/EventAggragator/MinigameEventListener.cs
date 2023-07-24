using UnityEngine;
using UnityEngine.Events;

public class MinigameEventListener : MonoBehaviour
{
    [SerializeField] MinigameEvent gameEvent;

    [SerializeField] GameObjectUnityEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(GameObject gameObject, MinigameType type)
    {
        response.Invoke(gameObject,type);
    }
}

[System.Serializable]
public class GameObjectUnityEvent : UnityEvent<GameObject,MinigameType> { }