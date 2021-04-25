using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class FilterUtils
    {
        /// <summary>
        /// Searches for a transform's child matching a given tag.
        /// </summary>
        /// <param name="parent">Parent transform to loop into</param>
        /// <param name="tag">Searched tag</param>
        /// <returns>The first child matching the specified tag. 
        /// Null if there aren't any matches</returns>
        public static GameObject FindChildWithTag(Transform parent, string tag)
        {
            foreach (Transform child in parent)
            {
                if (child.tag == tag) return child.gameObject;
            }
            return null;
        }

        /// <summary>
        /// Compares if given game states match. 
        /// </summary>
        /// <param name="currentGameState"></param>
        /// <param name="newGameState"></param>
        /// <returns>
        /// False if both states are the same (no game state change)
        /// True if input states don't match (game state change)</returns>
        public static bool CheckGameStateChange(GameStates currentGameState, GameStates newGameState)
        {
            if (newGameState == currentGameState)
                return false;
            return true;
        }
    }
}
