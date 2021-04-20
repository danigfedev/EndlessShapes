using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameProgressionData", menuName = "EndlessShapes/GameManagement/GameProgressionData", order = 1)]
public class GameProgressionData : ScriptableObject
{
    public GameStates currentState = GameStates.NO_STATE;
    public int currentDifficultyLevel = 0;
    public List<int> gameplayDifficultyLevels;

    public void ResetGameplayData()
    {
        currentState = GameStates.NO_STATE;
        currentDifficultyLevel = 0;
    }
}
