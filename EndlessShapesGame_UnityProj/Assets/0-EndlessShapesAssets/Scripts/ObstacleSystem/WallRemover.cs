using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSystem
{
    public class WallRemover : MonoBehaviour
    {
        public GameObject wallPool;


        public void OnTriggerEnter(Collider enteringObject)
        {
            Debug.Log("Removing Wall from " + enteringObject.name);

            //1 - Find Wall Slot
            GameObject wallSlot = Utils.FilterUtils.FindChildWithTag(enteringObject.transform,
                                            Utils.Taglist.wallSlotTag);

            RemoveWall(wallSlot);
            
        }

        /// <summary>
        /// Returns wall fragments in given wall slot to their corresponding pool
        /// </summary>
        /// <param name="wallSlot"></param>
        private void RemoveWall(GameObject wallSlot)
        {
            if (wallSlot.transform.childCount == 0) return;

            for (int wallFragmentIdx = wallSlot.transform.childCount-1; wallFragmentIdx>=0; wallFragmentIdx--)
            {
                Transform wallFragment = wallSlot.transform.GetChild(wallFragmentIdx);

                Debug.LogWarning(wallFragment.name);

                Transform wallFragmentParent = wallFragment
                        .GetComponent<WallFragmentIdentifier>().PoolParent;

                wallFragment.parent = wallFragmentParent;
                wallFragment.transform.localPosition = Vector3.zero;
            }
        }
    }
}
