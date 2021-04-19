using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Ground speed tests")]
    public bool TestingSpeed = false;
    public float TestSpeed = 50;
    [Space(10)]
    public TextMeshProUGUI testScore;

    private float distance = 0;

    //Game State Management
    private GameStates gameState;
    public delegate void OnGameStateChangeDelegate();
    public event OnGameStateChangeDelegate OnGameStateChangeEvent;
    public GameStates GameState {
        get { return gameState; }
        set
        {
            if (gameState == value) return;
            gameState = value;
            if (OnGameStateChangeEvent != null)
                OnGameStateChangeEvent();
            Debug.LogWarning("Game State Changed to " + gameState.ToString());
        }    
    }

    public GroundSettings groundSettings;

    private void Awake()
    {
        //groundSettings.currentGroundSpeed = groundSpeed;
        groundSettings.ResetCurrentSpeed();
    }
    
    void Start()
    {
        OnGameStateChangeEvent += OnGameStateChange;
        //GameState = GameStates.IDLE;
        //OnVariableChange += SpeedChangedCallback;
    }

    int frameStep = 3;
    int frameCount = 1;
    void Update()
    {
        //TESTING State change === TO BE DELETED
        if (Input.GetKeyUp(KeyCode.Space))
            GameState = GameStates.IDLE;

        if (frameCount < frameStep)
        {
            frameCount++;
            return;
        }
        frameCount = 1;

        //Speed tests
        if (TestingSpeed)
            ChangeSpeed(TestSpeed, 0);


        if (gameState == GameStates.PLAYING)
        {
            //NOTE: If i wanted to calculate distance gradually (matching ground tile velocity lerping),
            //That lerp process should be done here!
            distance += groundSettings.CurrentGroundSpeed * Time.deltaTime;
            testScore.text = ((int)distance).ToString();
        }
    }

    /*
    private void SpeedChangedCallback(float newSpeed)
    {
        Debug.LogWarning("[GameplayManager] Speed changed to: " + newSpeed);
        groundSettings.currentGroundSpeed = newSpeed;
    }
    */

    private void OnGameStateChange()
    {
        Debug.Log("[GameManagement] Game State changed to "+gameState.ToString());
        switch (gameState)
        {
            case GameStates.IDLE:
                ChangeSpeed(groundSettings.idleSpeed, 2);
                break;
            case GameStates.PLAYING:
                break;
            case GameStates.PAUSE:
                break;
            case GameStates.GAME_OVER:
                break;
        }
    }

    private void ChangeSpeed(float newSpeed, float transitionDuration)
    {
        StartCoroutine(groundSettings.ChangeSpeed(newSpeed, transitionDuration));
        //groundSettings.CurrentGroundSpeed = newSpeed;
    }
}
