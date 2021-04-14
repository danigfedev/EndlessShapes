using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    public void OnInputTriggerEnter(GameObject inputObject)
    {
        //Check validity
        if(inputObject.tag != tag)
        {
            Debug.LogWarning("YOU DIED");
        }
    }

    public void OnOutputTriggerEnter()
    {
        //Count gate
        //Trigger gate dissolve effect
    }
}
