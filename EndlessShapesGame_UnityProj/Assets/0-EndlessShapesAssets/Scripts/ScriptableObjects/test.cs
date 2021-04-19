using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = -1 * transform.forward * 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
