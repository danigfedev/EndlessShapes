using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObstacleSystem
{
    public class WallRemover : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void OnTriggerEnter(Collider enteringObject)
        {
            Debug.Log("Removing Wall from " + enteringObject.name);
        }
    }
}
