using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public TextMeshProUGUI testScore;

    public float testSpeedEvent = 50f; //TODO Divide by 50 to get speed in m/s (research more about this)
    private float groundSpeed = 50f;
    float distance = 0;


    public float GroundSpeed
    {
        get { return groundSpeed; }
        set
        {
            if (groundSpeed == value) return;
            groundSpeed = value;
            if (OnVariableChange != null)
                OnVariableChange(groundSpeed);
        }
    }
    public delegate void OnVariableChangeDelegate(float newSpeed);
    public event OnVariableChangeDelegate OnVariableChange;


    public GameplaySettings gameSettings;

    private void Awake()
    {
        gameSettings.groundSpeed = groundSpeed;
    }
    
    void Start()
    {
        OnVariableChange += SpeedChangedCallback;
    }

  
    void Update()
    {
        GroundSpeed = testSpeedEvent;


        
        distance += GroundSpeed * Time.deltaTime;
        testScore.text = ((int)distance).ToString();
    }

    private void SpeedChangedCallback(float newSpeed)
    {
        Debug.LogWarning("[GameplayManager] Speed changed to: " + newSpeed);
        gameSettings.groundSpeed = newSpeed;
    }
}
