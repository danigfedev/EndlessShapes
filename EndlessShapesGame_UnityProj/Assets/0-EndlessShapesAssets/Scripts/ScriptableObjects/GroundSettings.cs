using GroundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameplaySettings", menuName ="EndlessShapes/GameManagement/GameplaySettings", order = 1) ]
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

    public IEnumerator ChangeSpeed(float newSpeed, float transitionTime)
    {
        if (transitionTime <= 0)
        {
            CurrentGroundSpeed = newSpeed;
            yield break;
        }

        float timeFactor = 0;
        float initialSpeed = CurrentGroundSpeed;
        while (CurrentGroundSpeed < newSpeed)
        {
            CurrentGroundSpeed = Mathf.Lerp(initialSpeed, newSpeed, timeFactor);
            yield return new WaitForFixedUpdate();
            timeFactor += Time.fixedDeltaTime / transitionTime;
        }
    }
}
