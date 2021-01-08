using System;
using _Code.Observer.Listener;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
    IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
    [SerializeField] private E _gameEvent;
    public E GameEvent => _gameEvent;
    [SerializeField] private UER UnityEventResponse;

    private void OnEnable()
    {
        if (_gameEvent == null)
            return;

        GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (_gameEvent == null)
            return;

        GameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T item)
    {
        if(UnityEventResponse != null)
            UnityEventResponse.Invoke(item);
    }
}