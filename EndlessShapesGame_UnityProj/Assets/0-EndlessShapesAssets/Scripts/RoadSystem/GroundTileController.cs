using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GroundTileController : MonoBehaviour
{
    [Tooltip("This value neutralizes the fixedDeltaTime factor to give a " +
        "base speed of 1m/sec")]
    public float tileFactor = 50f; //Default fixed deltaTime is 0.02 (1/50). 
    public float tileSpeed = 1.0f;
    
    

    Rigidbody tileRigidbody;

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
        tileRigidbody.velocity = -1 * transform.forward * tileSpeed * tileFactor * Time.fixedDeltaTime;

        //Idea for game progression (dificulty increase): use Smooth damp or any of those methods to smoothly increase speed
        //from initialTileSpeed to targetTileSpeed.
        //Initially, both values will be equal, so target value should be applied directly.

        //float distance = tileRigidbody.velocity * gameTime; //Where gameTime measures the amount of time transcurred since the game started.
    }
}
