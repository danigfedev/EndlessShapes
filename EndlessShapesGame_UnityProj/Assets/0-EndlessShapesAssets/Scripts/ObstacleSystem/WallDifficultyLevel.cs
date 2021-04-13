using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSystem
{
    [System.Serializable]
    public class WallDifficultyLevel
    {
        //Range: [rangeMinLimit, rangeMaxLimit)
        public int rangeMinLimit; //Inclusive
        public int rangeMaxLimit; //Exclusive
        public List<int> excludedList;
    }
}