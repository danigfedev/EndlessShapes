using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallSystem
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