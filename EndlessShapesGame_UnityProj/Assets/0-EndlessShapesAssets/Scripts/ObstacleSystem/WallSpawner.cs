using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSystem
{
    public class WallSpawner : MonoBehaviour
    {
        public GameObject wallPool;
        [Tooltip("Wall framents' width. " +
            "Will be used to laterally separate wall fragments")]
        public float leftLanePosition;
        public float wallWidth;

        public int wallDifficultyLevel = 0;
        public WallDifficultyLevel[] wallDifficultyLevels;

        /*
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                GetWallMask();
        }
        */

        public void OnTriggerEnter(Collider enteringObject)
        {

            Debug.Log("Attaching Wall to " + enteringObject.name);
            
            GameObject wallSlot = FindChildWithTag(enteringObject.transform,
                                Utils.Taglist.wallSlotTag);


            WallMask wallMask = GetWallMask();
            BuildWall(wallSlot, wallMask);
        }

        private WallMask GetWallMask()
        {
            int maskSeed = GenerateRandomWallMaskSeed();
            string binaryMask = Convert.ToString(maskSeed, 2).PadLeft(3, '0');

            Debug.Log("Seed: " + maskSeed + "== Mask: " + binaryMask);
            
            char[] charMask = binaryMask.ToCharArray();

            WallMask mask = WallMask.CreateInitializedWallMask(
                            (int)char.GetNumericValue(charMask[0]),
                            (int)char.GetNumericValue(charMask[1]),
                            (int)char.GetNumericValue(charMask[2]));

            Debug.Log("Mask: [ " + charMask[0] + " " + charMask[1] + " " + charMask[2] +" ]");

            return mask;
        }

        /// <summary>
        /// Generates a valid int seed as base of wall mask generation
        /// </summary>
        /// <returns></returns>
        public int GenerateRandomWallMaskSeed()
        {
            WallDifficultyLevel level = wallDifficultyLevels[wallDifficultyLevel];

            int selectedSeed;
            bool validSelection = false;
            do
            {
                selectedSeed = UnityEngine.Random.Range(level.rangeMinLimit, level.rangeMaxLimit);
                validSelection = CheckMaskSeedValidity(level, selectedSeed);
            }
            while (!validSelection);

            return selectedSeed;
        }

        /// <summary>
        /// Checks whether the given wall mask seed is valid or not
        /// </summary>
        /// <param name="difficultyLevel"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        private bool CheckMaskSeedValidity(WallDifficultyLevel difficultyLevel, int seed)
        {
            return !difficultyLevel.excludedList.Contains(seed);
        }

        /// <summary>
        /// Builds a wall from given mask in given slot.
        /// Lanes always go from Left to Right
        /// </summary>
        /// <param name="wallSlot"></param>
        /// <param name="wallMask"></param>
        private void BuildWall(GameObject wallSlot, WallMask wallMask)
        {
            int maskIdx = 0;
            foreach (Transform lane in wallPool.transform)
            {
                Debug.Log("Lane name: " + lane.name);

                //Select wall or gate based on mask's value
                Debug.Log("ñpoijadwfpojiash " + wallMask.leftLaneValue);
                Debug.Log("YOQUESEEE: " + wallMask.ToArray()[maskIdx]);
                Transform selectedSubParent = lane.GetChild(wallMask.ToArray()[maskIdx]);
                int wallFragmentIndex = UnityEngine.Random.Range(0, selectedSubParent.childCount);
                Transform wallFragment = selectedSubParent.GetChild(wallFragmentIndex);
                
                //Place wall
                wallFragment.parent = wallSlot.transform;
                wallFragment.transform.localPosition = Vector3.right * (leftLanePosition + wallWidth * maskIdx);

                maskIdx++;
            }
        }

        /// <summary>
        /// Searches for a transform's child matching a given tag.
        /// </summary>
        /// <param name="parent">Parent transform to loop into</param>
        /// <param name="tag">Searched tag</param>
        /// <returns>The first child matching the specified tag. 
        /// Null if there aren't any matches</returns>
        private GameObject FindChildWithTag(Transform parent, string tag)
        {
            foreach (Transform child in parent)
            {
                if (child.tag == tag) return child.gameObject;
            }
            return null;
        }
    }
}
