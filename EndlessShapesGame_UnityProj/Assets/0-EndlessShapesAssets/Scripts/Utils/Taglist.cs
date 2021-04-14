using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Taglist
    {
        public static readonly string groundTile = "ground-tile";
        public static readonly string wallSlotTag = "wall-slot";

        public static readonly string cubeTag = "cube";
        public static readonly string pyramidTag = "pyramid";
        public static readonly string pentagonTag = "pentagon";
        public static readonly string obstacleTag = "obstacle";

        // Object pool
        public static readonly string wallPoolTag = "wall-pool";
        public static readonly string leftSubpool = "wall-pool-left";
        public static readonly string centerSubpool = "wall-pool-center";
        public static readonly string rightSubpool = "wall-pool-right";
    }
}