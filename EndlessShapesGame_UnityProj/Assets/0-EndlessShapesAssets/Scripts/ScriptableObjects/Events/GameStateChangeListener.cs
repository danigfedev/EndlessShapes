using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameStateChangeEvent : UnityEvent<GameStates> { }

public class GameStateChangeListener : MonoBehaviour
{
    public GameStateChangeEventSO gameStateChangeEventSO;
    public GameStateChangeEvent response;

    private void OnEnable()
    {
        gameStateChangeEventSO.AddListener(this);
    }

    private void OnDisable()
    {
        gameStateChangeEventSO.RemoveListener(this);
    }

    public void RaiseEvent(GameStates newGameState)
    {
        response.Invoke(newGameState);
    }
}
