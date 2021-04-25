using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    /// <summary>
    /// Class description:
    /// In charge of setting the initial state of the game
    /// Default value: MENU
    /// </summary>
    public class GameInitializer : MonoBehaviour
    {
        public GameStates initialGameState = GameStates.MENU;
        public GameStates idleGameState = GameStates.NO_STATE;
        [Header("ScriptableObjects")]
        public GameStateChangeEventSO gameStateChangeSO;
        public GameProgressionData gameplayData;

        private void Start()
        {
            gameStateChangeSO.RaiseEvent(initialGameState);
            //Important: Update Current state after raising the event
            // State change would not be detected otherwise
            gameplayData.currentState = initialGameState;
        }

        public void OnApplicationQuit()
        {
            Debug.LogWarning("[GameInitializer] On application Quit");
            gameplayData.currentState = idleGameState;
        }
    }
}