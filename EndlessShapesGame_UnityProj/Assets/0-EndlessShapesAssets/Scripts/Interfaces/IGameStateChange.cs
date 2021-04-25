using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateChange
{
    /// <summary>
    /// This method should be called whenever a game state change occurs
    /// </summary>
    /// <param name="newGameState">The new game state</param>
    public void OnGameStateChange(GameStates newGameState);
}
