using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSystem
{
    public class WallFragmentIdentifier : MonoBehaviour
    {
        public Transform PoolParent
        {
            get; set;
        }

        private void Awake()
        {
            PoolParent = transform.parent;
        }
    }
}