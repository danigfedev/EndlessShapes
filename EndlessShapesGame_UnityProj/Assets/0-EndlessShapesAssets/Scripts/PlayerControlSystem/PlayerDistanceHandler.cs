using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControlSystem
{

    public class PlayerDistanceHandler : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        public GameProgressionData gameProgressionData;
        public GroundSettings groundSettings;
        [Space(10)]
        [Header("Update optimization parameters")]
        public int frameStep = 3;
        int frameCount = 1;


        private float distance = 0;
        void Update()
        {
            if (!Utils.UpdateFrameCounter.CheckFrameCount(frameCount, frameStep))
                return;

            frameCount = 1;

            if (gameProgressionData.currentState == GameStates.PLAYING)
            {
                distance += groundSettings.CurrentGroundSpeed * Time.deltaTime;
                //testScore.text = ((int)distance).ToString();
            }
                
            //TODO PlayerData.Distance = value; > Implemented set with event
            // Gameplay canvas has a reference to PlayerData SO and every time it changes, 
            //UI reads that value from the SO and updates the corresponding text component
        }
    }
}
