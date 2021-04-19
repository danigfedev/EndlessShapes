using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroundSystem
{

    [RequireComponent(typeof(Rigidbody))]
    public class GroundTileController : MonoBehaviour
    {
        #region = Public Fields =

        public float transitionDuration = 2;
        public GroundSettings groundSettings;

        #endregion


        #region = Private Fields =

        Rigidbody tileRigidbody;

        #endregion

        private void Awake()
        {
            tileRigidbody = GetComponent<Rigidbody>();
            groundSettings.OnTileSpeedChangeEvent += ChangeSpeed;
        }


        void Start()
        {
            
            tileRigidbody.useGravity = false;
        }

        private void FixedUpdate()
        {
            //tileRigidbody.velocity = -1 * transform.forward * groundSettings.currentGroundSpeed * Time.fixedDeltaTime;
        }

        private void ChangeSpeed(float newSpeed)
        {
            ChangeRigidbodySpeed(newSpeed);

            /*
            if(newSpeed==0) //Do not lerp if speed is 0 (Pause, GameOver states)
                ChangeRigidbodySpeed(newSpeed);
            else
                StartCoroutine(ChangeSpeed(newSpeed, transitionDuration));
            */
        }

        /*
        private IEnumerator ChangeSpeed(float newSpeed, float transitionTime)
        {
            float timeFactor = 0;
            float initialSpeed = tileRigidbody.velocity.magnitude;
            float currentSpeed = initialSpeed;
            while (currentSpeed < newSpeed)
            {
                currentSpeed = Mathf.Lerp(initialSpeed, newSpeed, timeFactor);
                Debug.Log("Updating speed: " + currentSpeed);
                ChangeRigidbodySpeed(currentSpeed);
                yield return new WaitForFixedUpdate();
                timeFactor += Time.fixedDeltaTime / transitionTime;
            }
        }
        */

        private void ChangeRigidbodySpeed(float newSpeed)
        {
            tileRigidbody.velocity = -1 * transform.forward * newSpeed;// * Time.fixedDeltaTime;
        }
        
    }
}
