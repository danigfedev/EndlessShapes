using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameStateChangeEvent : UnityEvent<GameStates> { }

public class GameStateChangeListener : MonoBehaviour
{
    public GameStateChangeEvent gameStateChangeEvent;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void RaiseEvent(GameStates newGameState)
    {
        gameStateChangeEvent.Invoke(newGameState);
    }
}
