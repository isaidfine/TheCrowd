using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2border : MonoBehaviour
{  
    public float Xmax;
    public float Ymax;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -Xmax, Xmax);
        pos.y = Mathf.Clamp(pos.y, -Ymax, Ymax);
        pos.z=0;
        transform.position = pos;
        
    }
}
