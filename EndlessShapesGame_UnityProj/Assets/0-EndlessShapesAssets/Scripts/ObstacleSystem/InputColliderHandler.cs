using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ObstacleSystem
{
    public class InputColliderHandler : MonoBehaviour
    {
        public ObstacleTriggerEvent onTriggerEnterEvent;

        public void OnTriggerEnter(Collider inputObject)
        {
            onTriggerEnterEvent.Invoke(inputObject.gameObject);
        }
    }
}
