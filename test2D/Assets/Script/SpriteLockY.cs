using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLockY : MonoBehaviour
{
    private Vector3 relativePos;// Start is called before the first frame update
    private Quaternion rotation;

    void Start()
    {
        //Vector3 relativePos = new Vector3(0,1,1);
        Quaternion rotation=transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        // the second argument, upwards, defaults to Vector3.up
        transform.rotation = rotation;
        
    }
}
