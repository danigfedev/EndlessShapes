using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EG_EndlessShapes
{

    [RequireComponent(typeof(Rigidbody))]
    public class GroundTileController : MonoBehaviour
    {
        #region = Public Fields =
        
        [Tooltip("This value neutralizes the fixedDeltaTime factor to give a " +
            "base speed of 1m/sec")]
        public float tileFactor = 50f; //Default fixed deltaTime is 0.02 (1/50). 
        public float tileSpeed = 1.0f;
        public GameplaySettings gameSettings;

        #endregion


        #region = Private Fields =

        Rigidbody tileRigidbody;

        #endregion

        private void Awake()
        {
            tileRigidbody = GetComponent<Rigidbody>();
        }


        void Start()
        {
            tileRigidbody.useGravity = false;
        }

        private void FixedUpdate()
        {
            tileRigidbody.velocity = -1 * transform.forward * gameSettings.groundSpeed/*tileSpeed*/ * tileFactor * Time.fixedDeltaTime;

            //Idea for game progression (dificulty increase): use Smooth damp or any of those methods to smoothly increase speed
            //from initialTileSpeed to targetTileSpeed.
            //Initially, both values will be equal, so target value should be applied directly.

            //float distance = tileRigidbody.velocity * gameTime; //Where gameTime measures the amount of time transcurred since the game started.
        }
    }
}
