using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderWall : MonoBehaviour
{
    public float Xmax;
    public float Ymax;
    private Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 position = transform.position;
        
        position.x = Mathf.Clamp(position.x, -Xmax, Xmax);
        position.y = Mathf.Clamp(position.y, -Ymax, Ymax);
        transform.position = position;
        
    }
}
