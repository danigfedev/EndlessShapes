using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour, IGameStateChange
{
    [Header("UI Menu Panels")]
    public GameObject mainMenuPanel;
    public GameObject gameplayMenuPanel;
    public GameObject pauseMenuPanel;
    public GameObject gameOverMenuPanel;
    
    private GameObject currentVisibleMenu;
    
    /// <summary>
    /// Enables the corresponding UI Menu depending on game's new state
    /// </summary>
    /// <param name="newGameState"></param>
    public void OnGameStateChange(GameStates newGameState)
    {
        //throw new System.NotImplementedException();
        currentVisibleMenu.SetActive(false);

        switch (newGameState)
        {
            case GameStates.MENU:
                gameplayMenuPanel.SetActive(true);
                currentVisibleMenu = gameplayMenuPanel;
                break;
            case GameStates.FTUE:
                throw new System.NotImplementedException(
                    "[UI Manager] FTUE Menu functionality" +
                    "not implemented yet");
                break;
            case GameStates.PLAYING:
                gameplayMenuPanel.SetActive(true);
                currentVisibleMenu = gameplayMenuPanel;
                break;
            case GameStates.PAUSE:
                pauseMenuPanel.SetActive(true);
                currentVisibleMenu = pauseMenuPanel;
                break;
            case GameStates.GAME_OVER:
                gameOverMenuPanel.SetActive(true);
                currentVisibleMenu = gameOverMenuPanel;
                break;
            default:
                gameplayMenuPanel.SetActive(true);
                currentVisibleMenu = gameplayMenuPanel;
                break;
        }
    }

}
