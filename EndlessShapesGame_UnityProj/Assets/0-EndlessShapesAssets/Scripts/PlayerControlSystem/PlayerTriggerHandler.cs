using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerHandler : MonoBehaviour
{
    //public ObstacleTriggerEvent dieEvent;
    public UnityEvent dieEvent;
    public UnityEvent countGateEvent;

    /// <summary>
    /// Filters wall trigger by tag and triggers corresponding event
    /// Possible triggers:
    /// - Wall input trigger (wall type identifier)
    /// - Wall output trigger (gate counter)
    /// </summary>
    /// <param name="inputObject"></param>
    public void OnTriggerEnter(Collider inputObject)
    {
        string wallTag = inputObject.transform.parent.tag;
        if (wallTag == Utils.Taglist.gateCounterTag)
            countGateEvent.Invoke();
        else if (wallTag != tag)
        {
            dieEvent.Invoke();
        }
    }
}
