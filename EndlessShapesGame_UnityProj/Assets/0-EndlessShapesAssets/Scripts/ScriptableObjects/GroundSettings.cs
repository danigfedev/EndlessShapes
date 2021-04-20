using GroundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GroundSettings", menuName = "EndlessShapes/GameManagement/GroundSettings", order = 1) ]
public class GroundSettings : ScriptableObject
{
    [Header("Game State ground speed values")]
    public float idleSpeed = 10;
    public float pauseSpeed = 0;
    public float gameOverSpeed = 0;
    public List<GameplaySpeed> gameplaySpeedList;

    private float currentGroundSpeed;
    public float CurrentGroundSpeed
    {
        get { return currentGroundSpeed; }
        set
        {
            if (currentGroundSpeed == value) return;
            currentGroundSpeed = value;
            if (OnTileSpeedChangeEvent != null)
                OnTileSpeedChangeEvent(currentGroundSpeed);
        }
    }
    public delegate void OnTileSpeedChangeDelegate(float newSpeed);
    public event OnTileSpeedChangeDelegate OnTileSpeedChangeEvent;

    public void ResetCurrentSpeed()
    {
        currentGroundSpeed = 0;
    }
}
