using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallSystem
{
    /// <summary>
    /// A wall mask is a binary representation of a wall, where:
    /// 0 = wall
    /// 1 = gate
    /// </summary>
    public class WallMask
    {
        public int leftLaneValue;
        public int centerLaneValue;
        public int rightLaneValue;

        public static WallMask CreateInitializedWallMask(int l, int c, int r)
        {
            WallMask mask = new WallMask();
            mask.leftLaneValue = l;
            mask.centerLaneValue = c;
            mask.rightLaneValue = r;
            return mask;
        }

        public int[] ToArray()
        {
            int[] maskArray = new int[3];
            maskArray[0] = leftLaneValue;
            maskArray[1] = centerLaneValue;
            maskArray[2] = rightLaneValue;

            return maskArray;
        }
    }
}
