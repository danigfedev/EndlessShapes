
using UnityEngine;

/// <summary>
/// This class is a data container for gameplay speed values
/// Each object contains a ground speed value and its corresponding difficulty level
/// </summary>
/// 

namespace GroundSystem
{
    [System.Serializable]
    public class GameplaySpeed
    {
        public int difficultyLevel;
        public float speedValue;
    }

}
