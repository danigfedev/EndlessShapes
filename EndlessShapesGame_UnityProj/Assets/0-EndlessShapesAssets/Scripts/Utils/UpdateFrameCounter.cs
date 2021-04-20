using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class UpdateFrameCounter
    {
        public static bool CheckFrameCount(int frameCount, int frameStep)
        {
            if (frameCount < frameStep)
            {
                frameCount++;
                return false;
            }
            return true;
        }
    }
}
