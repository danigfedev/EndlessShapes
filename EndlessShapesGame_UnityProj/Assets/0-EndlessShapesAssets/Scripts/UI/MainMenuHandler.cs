using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public GameStateChangeEventSO gameStateChangeEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void PlayButton_OnClickEvent()
    {
        gameStateChangeEvent.RaiseEvent(GameStates.PLAYING);
    }

}
