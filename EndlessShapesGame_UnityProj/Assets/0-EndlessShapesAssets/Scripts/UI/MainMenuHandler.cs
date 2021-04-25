using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public GameStates playButtonState = GameStates.PLAYING;
    public GameStates optionsButtonState = GameStates.MENU;
    public GameStates creditsButtonState = GameStates.MENU;
    [Header("Scriptable Objects")]
    public GameStateChangeEventSO gameStateChangeEvent;
    public GameProgressionData gameplayData;

    public void PlayButton_OnClickEvent()
    {
        gameStateChangeEvent.RaiseEvent(playButtonState);
        gameplayData.currentState = playButtonState;

    }

}
