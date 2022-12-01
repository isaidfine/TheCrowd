using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController_position : MonoBehaviour
{
    public float movingSpeed;
    public float Xmax;
    public float Ymax;
    private float h;
    private float v;
    private Rigidbody rb;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + movingSpeed * h * Time.deltaTime;
        position.y = position.y + movingSpeed * v * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -Xmax, Xmax);
        position.y = Mathf.Clamp(position.y, -Ymax, Ymax);
        // transform.LookAt(position);
        transform.position = position;


    }
}
