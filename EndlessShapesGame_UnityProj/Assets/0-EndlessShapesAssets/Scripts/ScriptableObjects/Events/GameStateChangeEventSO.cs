using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStateChangeEvent", menuName = "EndlessShapes/Events/GameStateChangeEvent", order = 1)]
public class GameStateChangeEventSO : ScriptableObject
{
    private List<GameStateChangeListener> listeners = new List<GameStateChangeListener>(); 

    public void AddListener(GameStateChangeListener newListener)
    {
        listeners.Add(newListener);
    }

    public void RemoveListener(GameStateChangeListener removingListener)
    {
        listeners.Remove(removingListener);
    }

    public void RaiseEvent(GameStates newGameState)
    {
        foreach (GameStateChangeListener listener in listeners)
            listener.RaiseEvent(newGameState);
    }
}
