using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallSystem
{
    public class WallSystemManager : MonoBehaviour, IGameStateChange
    {
        public GameObject wallSpawner;
        public GameObject wallRemover;
        [Header("Scriptable Objects")]
        public GameProgressionData gameplayData;

        public void OnGameStateChange(GameStates newGameState)
        {
            if(!Utils.FilterUtils.CheckGameStateChange(gameplayData.currentState, newGameState))
                return;

            Debug.Log("[WallSystemManager] Game state changed to: " + newGameState);
            if(newGameState== GameStates.PLAYING)
            {
                wallSpawner.SetActive(true);
                wallRemover.SetActive(true);
            }
            else
            {
                wallSpawner.SetActive(false);
                wallRemover.SetActive(false);
            }
        }
    }
}
