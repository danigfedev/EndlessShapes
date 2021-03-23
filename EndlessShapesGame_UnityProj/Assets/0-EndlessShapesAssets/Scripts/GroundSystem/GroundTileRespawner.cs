using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EG_EndlessShapes
{
    public enum GroundMotionDirections
    {
        POSITIVE_Z = 1,
        NEGATIVE_Z = -1
    };

    public class GroundTileRespawner : MonoBehaviour
    {
        #region = Public fields =

        [Tooltip("Attach Ground Tiles ordered in Editor (1st Tile closest to Respawner, last the farthest)")]
        public List<GameObject> visibleGroundTiles;
        [Tooltip("The length of a single Ground Tile in Scene Units")]
        public float tileLength = 100f;
        [Tooltip("Select the motion direction of the Ground Tiles (Controlled by GroundTileController)")]
        public GroundMotionDirections groundMotionDirection = GroundMotionDirections.NEGATIVE_Z;

        #endregion

        #region = Private fields =
        
        int visibleGroundTileCount;
        int groundDirection;

        #endregion


        private void Start()
        {
            groundDirection = (int) groundMotionDirection;

            try
            {
                visibleGroundTileCount = visibleGroundTiles.Count;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Problems with Ground Tile List initialization", ex);
            } 
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("A Ground Tile collided");

            GameObject collidingTile = other.gameObject;

            // 1 - Update colliding tile's position.
            collidingTile.transform.position = visibleGroundTiles[visibleGroundTileCount - 1].transform.position
                                            - collidingTile.transform.forward * groundDirection * tileLength;

            // 2 - Reorder groundTileList
            visibleGroundTiles.RemoveAt(0); //RemoveAt() is more efficient than Remove()
            visibleGroundTiles.Add(collidingTile);
        }

    }
}
